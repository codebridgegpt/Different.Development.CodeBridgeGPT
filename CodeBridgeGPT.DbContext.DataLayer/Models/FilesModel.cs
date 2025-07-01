using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CodeBridgeGPT.DbContext.DataLayer.Models
{
    public class FilesModel
    {
        [JsonProperty("filePath")]
        [Key]
        public string FilePath { get; set; } = default!;
        public string Content { get; set; } = default!;
        public string Action { get; set; } = default!;
        public string Message { get; set; } = default!;

        //public bool InsertAfter { get; set; } = true;
    }
}
