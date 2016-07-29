using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsiHack.Base
{
    [Model]
    public class Status
    {
        public Status() { }
        public Status(HttpStatusCode code, string message="", string details = "")
        {
            StatusCode = code;
            Message = message;
            Details = details;
        }
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public string Message { get; set; } = "";
        public string Details { get; set; } = "";
    }
}