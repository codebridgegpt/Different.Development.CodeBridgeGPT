using CodeBridgePlatform.AI.Core.Models;

namespace CodeBridgePlatform.AI.Core.Interfaces
{
    public interface IGitHubProcessor
    {
        Task<string> CodeFilesPushGitHubAsync(long installationId, string repository, string loginuser, GitHubProcessModel files);
        Task<string> GenerateInstallationTokenAsync(long installationId);
        Task<long?> GenerateInstallationIdAsync(string owner);
    }
}
