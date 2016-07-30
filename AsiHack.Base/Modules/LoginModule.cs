using AsiHack.Base.Models;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsiHack.Base.Modules
{
    public class LoginModule: NancyModule
    {
        public LoginModule()
        {            
            Get["/restricted"] = parameters => {
                
                // Called when the user visits the login page or is redirected here because
                // an attempt was made to access a restricted resource. It should return
                // the view that contains the login form
                return Response.AsJson(new Status(0,"Login Failed"), HttpStatusCode.Forbidden);
            };

            Get["/logout"] = _ => {
                return this.LogoutAndRedirect("/");
            };

            Post["/register"] = _ => "Not supported yet!";

            Post["/login"] = _ => {
                var login = this.Bind<UserLogin>();

                if (login.Username == "test" && login.Password == "pass") {
                    this.LoginWithoutRedirect(Guid.NewGuid()).WithContentType("application/json");
                    return Response.AsJson(new Status(0, "Login success")).WithStatusCode(HttpStatusCode.OK);
                }
                else
                    return Response.AsJson(new Status(1,"Login failed")).WithStatusCode(HttpStatusCode.OK);
            };
        }

    }
}