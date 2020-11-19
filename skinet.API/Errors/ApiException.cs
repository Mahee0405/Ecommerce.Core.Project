using System;
namespace skinet.API.Errors
{
    public class ApiException : ApiResponse
    {
        public ApiException()
        {
        }
        public string  Details { get; set; }


        public ApiException(int statusCode, string message = null,string details=null) : base(statusCode, message)
        {
            Details = details;
        }
    }
}
