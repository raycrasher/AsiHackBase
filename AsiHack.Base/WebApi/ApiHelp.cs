using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsiHack.Base.WebApi
{
    public class ApiHelp: NancyModule
    {
        public ApiHelp()
        {
            Get["apihelp"] = parameters => View["api"];
        }

        
    }
}