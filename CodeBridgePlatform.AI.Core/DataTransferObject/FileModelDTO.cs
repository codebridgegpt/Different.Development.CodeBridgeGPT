namespace CodeBridgePlatform.AI.Core.DataTransferObject
{
    public class FileModelDTO
    {
        public string FilePath { get; set; } = default!;
        public string Content { get; set; } = default!;
        public string Action { get; set; } = default!;
        public string Message { get; set; } = default!;
    }
}
