namespace CodeBridgeGPT.Response.Models
{
    public class GptTaskHistory
    {
        public string TaskId { get; set; } = default!; // REQ-12345
        public string Intent { get; set; } = default!; // TASK_EXECUTION, etc.
        public DateTime ExecutedAt { get; set; }
        public string? ExecutionResponseId { get; set; }
    }
}
