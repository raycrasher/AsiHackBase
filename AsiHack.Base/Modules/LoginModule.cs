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
                    return this.LoginAndRedirect(Guid.NewGuid());
                }
                else
                    return Response.AsJson(new Status(0,"Login failed"), HttpStatusCode.Forbidden);
            };
        }

    }
}