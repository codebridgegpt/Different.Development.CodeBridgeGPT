using Newtonsoft.Json;

namespace CodeBridgeGPT.AI.Models
{
    public class RepositoryModel
    {
        [JsonProperty("name")]
        public string Name { get; set; } = default!;
        
        [JsonProperty("description")]
        public string Description { get; set; } = default!;

        [JsonProperty("homepage")]
        public string Homepage { get; set; } = default!;
        
        [JsonProperty("private")]
        public bool Private { get; set; } = false;

        [JsonProperty("has_issues")]
        public bool HasIssues { get; set; } = true;

        [JsonProperty("has_projects")]
        public bool HasProjects { get; set; } = true;

        [JsonProperty("has_wiki")]
        public bool HasWiki { get; set; } = true;
        
        [JsonProperty("autoInit")]
        public bool AutoInit { get; set; } = true;

        [JsonProperty("visibility")]
        public string Visibility { get; set; } = default!;
        
        [JsonProperty("hasDownloads")]
        public bool HasDownloads { get; set; } = default!;
        
        [JsonProperty("isTemplate")]
        public bool IsTemplate { get; set; } = default!;
        
        [JsonProperty("gitignoreTemplate")]
        public string GitignoreTemplate { get; set; } = default!;
        
        [JsonProperty("licenseTemplate")]
        public string LicenseTemplate { get; set; } = default!;
        
        [JsonProperty("allowSquashMerge")]
        public bool AllowSquashMerge { get; set; } = default!;
        
        [JsonProperty("allowMergeCommit")]
        public bool AllowMergeCommit { get; set; } = default!;
        
        [JsonProperty("allowRebaseMerge")]
        public bool AllowRebaseMerge { get; set; } = default!;
        
        [JsonProperty("allowAutoMerge")]
        public bool AllowAutoMerge { get; set; } = default!;
        
        [JsonProperty("deleteBranchOnMerge")]
        public bool DeleteBranchOnMerge { get; set; } = default!;
        
        [JsonProperty("useSquashPrTitleAsDefault")]
        public bool UseSquashPrTitleAsDefault { get; set; } = default!;
        
        [JsonProperty("squashMergeCommitTitle")]
        public string SquashMergeCommitTitle { get; set; } = default!;
        
        [JsonProperty("squashMergeCommitMessage")]
        public string SquashMergeCommitMessage { get; set; } = default!;
        
        [JsonProperty("mergeCommitTitle")]
        public string MergeCommitTitle { get; set; } = default!;
        
        [JsonProperty("mergeCommitMessage")]
        public string MergeCommitMessage { get; set; } = default!;
    }
}
