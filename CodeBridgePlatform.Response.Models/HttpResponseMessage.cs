using Newtonsoft.Json;

namespace CodeBridgePlatform.Response.Models
{
    public class HttpResponseMessage<T>
    {
        private readonly List<string> _error = [];
        
        [JsonProperty("errors")]
        public List<string> Errors => _error;

        public bool IsSuccess { get; private set; }

        [JsonProperty("statusCode")]
        public int StatusCode { get; private set; }

        [JsonProperty("content")]
        public string? Content { get; private set; }
        
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("requestId")]
        public Guid RequestId { get; set; }

        [JsonProperty("result")]
        public string? Result { get; set; }

        public T? Data { get; private set; }

        [JsonProperty("usage")]
        public GPTTokenUtilities? Usage { get; set; }

        public void SetError(string error) { _error.Add(error); IsSuccess = false; }

        public void SetSuccess(int statusCode, string content, T data, bool issuccess) { StatusCode = statusCode; Content = content; Data = data; IsSuccess = issuccess; }
    }
}
