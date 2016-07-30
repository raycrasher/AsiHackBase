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

            Post["/SetData"] = _ =>
            {
                /*var repo = SimpleIoc.Default.GetInstance<Repository>();
                List<FlashCardPostData> data;
                using (var stream = new System.IO.StreamReader(Request.Body))
                {
                    var theString = System.Text.RegularExpressions.Regex.Unescape(stream.ReadToEnd());
                    data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FlashCardPostData>>(theString);
                }
                if (data == null) return Response.AsJson(new Status(0, "Unable to parse input JSON"));
                foreach (var d in data)
                {
                    repo.Cards.Add(d.CreateFlashCard());
                }

                repo.SaveChanges();*/
                return Response.AsJson(new Status(1, "OK", $"Added {data.Count} items"));
            };
        }

    }
}