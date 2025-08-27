using Newtonsoft.Json;

namespace CodeBridgeGPT.Response.Models
{
    public sealed class GPTTokenUtilities
    {
        [JsonProperty("promptTokens")]
        public int PromptTokens { get; set; }

        [JsonProperty("completionTokens")]
        public int CompletionTokens { get; set; }

        [JsonProperty("totalTokens")]
        public int TotalTokens { get; set; }
    }
}
