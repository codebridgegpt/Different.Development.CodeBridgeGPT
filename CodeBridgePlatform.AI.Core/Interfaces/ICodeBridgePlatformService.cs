using CodeBridgePlatform.AI.Core.Models;
using Microsoft.SemanticKernel;

namespace CodeBridgePlatform.AI.Core.Interfaces
{
    public interface ICodeBridgePlatformService
    {
        Task<CodeBridgePlatformResponseModel> GenerateCodeFromPromptAsync(CodeBridgePlatformRequestModel request);
        Kernel GetKernel();
    }
}
