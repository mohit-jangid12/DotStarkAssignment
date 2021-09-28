using System;
using System.Collections.Generic;
using System.Text;

namespace DotStarkTest.Core.ViewModel
{
    public class ResponseVM
    {
        public bool Status { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
    public static class HTTPStatusCode
    {
        public const int OK = 200;
        public const int NotFound = 404;
        public const int BadRequest = 400;
        public const int CatchException = 501;
        public const int Unauthorized = 401;
    }
}
