namespace CodeBridgeGPT.Response.Models
{
    public class GptTrackedFile
    {
        public Guid FileId { get; set; }
        public string Path { get; set; } = default!;
        public string ContentHash { get; set; } = default!;
        public string Branch { get; set; } = "master";
        public string? CommitSha { get; set; }
        public bool HumanEdited { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<GptFileCapability> Capabilities { get; set; } = [];
        public ICollection<GptFileDependency> Dependencies { get; set; } = [];
    }
}
