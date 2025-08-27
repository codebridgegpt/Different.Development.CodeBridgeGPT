using CodeBridgePlatform.AI.Core.Models;
using Microsoft.SemanticKernel;

namespace CodeBridgePlatform.AI.Core.Interfaces
{
    public interface IKernelService
    {
        Task<CodeBridgeGptResponseModel> GenerateCodeFromPromptAsync(CodeBridgeGptRequestModel request);
        Kernel GetKernel();
    }
}
