using Newtonsoft.Json;

namespace CodeBridgePlatform.AI.Core.Models
{
    public class CodeBridgePlatformResponseModel
    {
        [JsonProperty("responseId")]
        public string TaskResponseId { get; set; } = default!;

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; } = default!;

        [JsonProperty("files")]
        public List<FilesModel> Files { get; set; } = [];
    }
}
