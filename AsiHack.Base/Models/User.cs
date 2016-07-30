using Nancy.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsiHack.Base.Models
{
    [Model]
    public class User: IUserIdentity
    {
        public Guid Id { get; set; }
        public List<string> Claims { get; set; } = new List<string>();
        IEnumerable<string> IUserIdentity.Claims => Claims;

        public string UserName { get; set; }
        public byte[] HashedPassword { get; set; }
    }

    [Model]
    public class UserLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}