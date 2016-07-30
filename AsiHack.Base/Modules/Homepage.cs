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
    public class Homepage : NancyModule
    {
        public Homepage()
        {
            Get["/Homepage"] = _ =>
            {
                return View["Homepage"];
            };
            Get["/TopNav"] = _ =>
            {
                return View["TopNav"];
            };
            Get["/SideNav"] = _ =>
            {
                return View["SideNav"];
            };
        }

    }
}