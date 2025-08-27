namespace CodeBridgePlatform.Response.Models
{
    public class GptFileCapability
    {
        public int Id { get; set; }
        public Guid FileId { get; set; }
        public string Kind { get; set; } = "provides"; // provides|consumes
        public string Name { get; set; } = default!;   // e.g., api.contact.post
    }
}
