namespace CodeBridgePlatform.AI.Core.Models
{
    public class UpdateDetailsModel
    {
        public string SearchString { get; set; } = default!;
        public bool InsertAfter { get; set; } = true;
        public string Content { get; set; } = default!;
    }
}
