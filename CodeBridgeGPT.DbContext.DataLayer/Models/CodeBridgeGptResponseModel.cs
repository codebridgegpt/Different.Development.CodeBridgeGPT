using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CodeBridgeGPT.DbContext.DataLayer.Models
{
    public class CodeBridgeGptResponseModel
    {
        [JsonProperty("responseId")]
        [Key]
        public string TaskResponseId { get; set; } = default!;
        public string Timestamp { get; set; } = default!;
        public string UserId { get; set; } = default!;
        public List<FilesModel> Files { get; set; } = [];
    }
}
