using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsiHack.Base.Services
{
    public class DbContext
    {
        public IDatabase Database { get; }

        public DbContext()
        {
            Database = new Database(Properties.Settings.Default.ConnectionString);

        }
    }
}