using System.Net;

namespace WebApplication9
{
    public class ExceptionFilter: Exception
    {
        public ExceptionFilter(HttpStatusCode statusCode, object? value =null) {
            _statusCode = statusCode;
            _value = value;
        }

        public HttpStatusCode _statusCode { get; set; }
        public object? _value {  get; set; }


    }
}
