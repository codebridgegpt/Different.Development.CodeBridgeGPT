using System.Text.Json.Serialization;

namespace CodeBridgeGPT.Response.Models
{
    public sealed class GPTTokenUtilities
    {
        [JsonPropertyName("promptTokens")]
        public int PromptTokens { get; set; }

        [JsonPropertyName("completionTokens")]
        public int CompletionTokens { get; set; }

        [JsonPropertyName("totalTokens")]
        public int TotalTokens { get; set; }
    }
}
