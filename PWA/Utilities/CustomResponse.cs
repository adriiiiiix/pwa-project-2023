using System.Net;

namespace PWA.Utilities
{
    public sealed class CustomResponse<T>
    {
        public bool IsSuccessful { get; set; }
        public HttpStatusCode Code { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    } 
}
