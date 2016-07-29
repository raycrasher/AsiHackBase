using Nancy.Authentication.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.Security;
using AsiHack.Base.Models;

namespace AsiHack.Base.Services
{
    public class Authentication : IUserMapper
    {
        public IUserIdentity GetUserFromIdentifier(Guid identifier, NancyContext context)
        {
            return new User
            {
                UserName = "testUser"
            };
        }
    }
}