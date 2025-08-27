using CodeBridgePlatform.AI.Core.Models;

namespace CodeBridgePlatform.AI.Core.Interfaces
{
    public interface IGitCommitProcessor
    {
        Task<string> CreateOrUpdateFileAsync(GitHubContentUpdateRequest request, string token);
    }
}
