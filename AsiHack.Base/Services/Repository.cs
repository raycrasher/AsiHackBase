using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AsiHack.Base.Models;
using System.Data.Entity;

namespace AsiHack.Base.Services
{
    public interface IRepository
    {
        IEnumerable<User> Users { get; }
    }

    public class Repository: DbContext, IRepository
    {
        IDbSet<User> Users;
        IEnumerable<User> IRepository.Users => Users;

        public Repository()
        {
            
        }
    }
}