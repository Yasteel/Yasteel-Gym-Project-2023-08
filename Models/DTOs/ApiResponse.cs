using System.Net;

namespace Models.DTOs
{
    public class ApiResponse
    {
        public bool Success { get; set; }

        public string StatusCode { get; set; }

        public HttpStatusCode Code { get; set; }

        public string? Message { get; set; }

        public object? Payload { get; set; }
    }
}
