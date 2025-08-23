using System.Text.Json.Serialization;

namespace CodeBridgeGPT.Response.Models
{
    public class GPTResponseMessage<T>
    {
        private readonly List<string> _error = [];
        
        [JsonPropertyName("errors")]
        public List<string> Errors => _error;

        public bool IsSuccess { get; private set; }

        [JsonPropertyName("statusCode")]
        public int StatusCode { get; private set; }

        [JsonPropertyName("content")]
        public string? Content { get; private set; }
        
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonPropertyName("requestId")]
        public Guid RequestId { get; set; }

        [JsonPropertyName("result")]
        public string? Result { get; set; }

        public T? Data { get; private set; }

        [JsonPropertyName("usage")]
        public GPTTokenUtilities? Usage { get; set; }

        public void SetError(string error) { _error.Add(error); IsSuccess = false; }

        public void SetSuccess(int statusCode, string content, T data, bool issuccess) { StatusCode = statusCode; Content = content; Data = data; IsSuccess = issuccess; }

    }
}
