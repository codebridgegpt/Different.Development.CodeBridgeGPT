namespace CodeBridgePlatform.Response.Models
{
    public class GptFileDependency
    {
        public int Id { get; set; }
        public Guid FileId { get; set; }
        public Guid DependsOnFileId { get; set; }
        public string Relationship { get; set; } = "compile-time"; // compile-time|runtime
    }
}
