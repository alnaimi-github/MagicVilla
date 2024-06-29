using System.Net;

namespace MagicVilla_Web.Dto.ResponseDto
{
    public class ApiResponse
    {
        public object? Result { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public List<string>? ErrorMessages { get; set; }
    }
}
