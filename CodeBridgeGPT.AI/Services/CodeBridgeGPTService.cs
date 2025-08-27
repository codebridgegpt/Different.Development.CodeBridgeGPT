using CodeBridgePlatform.AI.Core.Interfaces;
using CodeBridgePlatform.AI.Core.Models;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace CodeBridgePlatform.AI.Core.Services
{
    public class CodeBridgeGPTService : IKernelService
    {
        private readonly string _repository;
        private const string token = "";

        private readonly Kernel _kernelServices;
        private readonly IConfiguration _configuration;
        private readonly IChatCompletionService _chatService;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IGitCommitProcessor _gitCommitProcessor;
        private readonly IPromptValidator _inspectorService;

        public CodeBridgeGPTService(IConfiguration configuration, IHttpClientFactory httpClientFactory, IGitCommitProcessor gitCommitProcessor, IPromptValidator inspectorService)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            var apiKey = _configuration["KernelSettings:ApiKey"];
            var model = _configuration["KernelSettings:Model"] ?? "gpt-3.5-turbo";
            _repository = _configuration["GitHub:repository"] ?? string.Empty;

            if (string.IsNullOrWhiteSpace(apiKey) || string.IsNullOrWhiteSpace(model))
            {
                var missingItems = new List<string>();
                if (string.IsNullOrWhiteSpace(apiKey)) missingItems.Add(nameof(apiKey));
                if (string.IsNullOrWhiteSpace(model)) missingItems.Add(nameof(model));

                throw new InvalidOperationException($"Missing configuration: {string.Join(", ", missingItems)}");
            }


            var builder = Kernel.CreateBuilder();
            builder.AddOpenAIChatCompletion(model, apiKey);
            _kernelServices = builder.Build();

            _chatService = _kernelServices.GetRequiredService<IChatCompletionService>();
            _httpClientFactory = httpClientFactory;
            _gitCommitProcessor = gitCommitProcessor;
            _inspectorService = inspectorService;
        }

        public Kernel GetKernel() => _kernelServices;

        public async Task<CodeBridgeGptResponseModel> GenerateCodeFromPromptAsync(CodeBridgeGptRequestModel request)
        {
            var promptError = _inspectorService.ValidateStringPrompt(request.TaskExecutionPrompt);
            if (promptError.Count > 0) throw new Exception($"TaskExecutionPrompt is invalid in validation test");

            if (request.RepositoryName == _repository)
            {
                throw new InvalidOperationException("Invalid target repository. Cannot commit to the source code repository.");
            }
            var chat = new ChatHistory();
            chat.AddUserMessage(BuildPromptFromRequest(request));

            var result = await _chatService.GetChatMessageContentAsync(chat);

            if (result == null || string.IsNullOrWhiteSpace(result.Content))
                throw new InvalidOperationException("AI bot returned an empty response.");

            var gptresponse = JsonConvert.DeserializeObject<CodeBridgeGptResponseModel>(result.Content) ?? throw new InvalidOperationException("Failed to parse AI response as JSON.");

            if (string.IsNullOrWhiteSpace(gptresponse.TaskResponseId)) throw new InvalidOperationException("Not a valid response, must contain a TaskResponseId.");

            GitHubCommitter gitHubCommitter = new()
            {
                Name = "Abhitosh Kumar",
                Email = "kumarabhitosh678@gmail.com"
            };
            string owner = _configuration["GitHub:owner"] ?? throw new InvalidOperationException("TargetRepositoryOwner is not specified in the request or configuration.");
            string branch = await CreateFeatureBranchAsync(owner, request.RepositoryName);
            var commitrequest = await MapGptResponseToGitHubRequest(gptresponse, owner, request.RepositoryName, branch, gitHubCommitter);
            await _gitCommitProcessor.CreateOrUpdateFileAsync(commitrequest, token);

            return gptresponse;
        }

        private static string BuildPromptFromRequest(CodeBridgeGptRequestModel request)
        {
            var sb = new StringBuilder();
            sb.AppendLine(request.TaskExecutionPrompt);
            sb.AppendLine();
            sb.AppendLine("Context: (From repository):");
            sb.AppendLine($"Source Repository: {request.RepositoryName}");
            sb.AppendLine(JsonConvert.SerializeObject(request.Context, Formatting.Indented));
            return sb.ToString();
        }

        private async Task<GitHubContentUpdateRequest> MapGptResponseToGitHubRequest(
        CodeBridgeGptResponseModel gptresponse, string owner, string repo, string branch, GitHubCommitter committer)
        {
            if (!await RepositoryExistsAsync(owner, repo))
            {
                throw new InvalidOperationException($"GitHub repository '{owner}/{repo}' does not exist.");
            }
            var commitPayload = new GitHubContentUpdateRequest
            {
                ResponseId = gptresponse.TaskResponseId,
                Owner = owner,
                Repo = repo,
                Committer = committer,
                Files = gptresponse.Files.Select(file => new GithubFileContentModel
                {
                    FilePath = file.FilePath,
                    Content = file.Content,
                    Action = file.Action,
                    Message = $"Auto commit message: {gptresponse.TaskResponseId}"
                }).ToList()
            };
            return commitPayload;
        }

        private async Task<bool> RepositoryExistsAsync(string owner, string repo)
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.UserAgent.ParseAdd("CodeBridgeGPT"); // GitHub requires a User-Agent header

            var response = await client.GetAsync($"https://api.github.com/repos/{owner}/{repo}");

            return response.IsSuccessStatusCode;
        }

        private async Task<string> CreateFeatureBranchAsync(string owner, string repo)
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.UserAgent.ParseAdd("CodeBridgeGPT");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            string baseBranch = "master"; // Or "main" based on your repo
            var baseBranchResponse = await client.GetAsync($"https://api.github.com/repos/{owner}/{repo}/branches/{baseBranch}");

            if (!baseBranchResponse.IsSuccessStatusCode)
                throw new InvalidOperationException($"Base branch '{baseBranch}' not found in repo '{owner}/{repo}'");

            var baseBranchJson = await baseBranchResponse.Content.ReadAsStringAsync();
            dynamic branchData = JsonConvert.DeserializeObject(baseBranchJson) ?? throw new NullReferenceException();
            string baseSha = branchData.commit.sha;

            // Create unique feature branch name
            string branchPrefix = "feature/gptcommitbranch-";
            int branchIndex = DateTime.UtcNow.Millisecond; // simplistic unique ID (can be replaced with GUID or API check)
            string newBranchName = $"{branchPrefix}{branchIndex}";

            var payload = new
            {
                @ref = $"refs/heads/{newBranchName}",
                sha = baseSha
            };

            var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.UserAgent.ParseAdd("CodeBridgeGPT");
            var createBranchResponse = await client.PostAsync($"https://api.github.com/repos/{owner}/{repo}/git/refs", content);

            if (!createBranchResponse.IsSuccessStatusCode)
                throw new InvalidOperationException("Failed to create feature branch on GitHub.");

            return newBranchName;
        }

    }
}
