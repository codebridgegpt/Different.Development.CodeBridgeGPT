using CodeBridgePlatform.AI.Core.Models;

namespace CodeBridgePlatform.AI.Core.Interfaces
{
    public interface ICreateRepository
    {
        Task<string> CreateNewRepositoryAsync(string orgnisation, RepositoryModel repository, string token);
    }
}
