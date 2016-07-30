using Nancy;
using Nancy.Security;
using Nancy.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AsiHack.Base.Services;
using AsiHack.Base.Models;

namespace AsiHack.Base.Modules
{
    public class DataModule: NancyModule
    {
        class FlashCardPostData
        {
            public string Id { get; set; }
            public string Word { get; set; }
            public string HowToRead { get; set; }
            public string Meaning { get; set; }
            public string Sample { get; set; }
            public FlashCard CreateFlashCard() => new FlashCard
            {
                Word = Word,
                HowToRead = HowToRead,
                Meaning = Meaning,
                Sample = Sample
            };
        }

        public DataModule()
        {            
            //this.RequiresAuthentication();
            var repo = SimpleIoc.Default.GetInstance<Repository>();

            Post["/SetData"] = _ =>
            {
                List<FlashCardPostData> data;
                using (var stream = new System.IO.StreamReader(Request.Body))
                {
                    var theString = System.Text.RegularExpressions.Regex.Unescape(stream.ReadToEnd());
                    data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FlashCardPostData>>(theString);
                }
                if (data == null) return Response.AsJson(new Status(0, "Unable to parse input JSON"));
                foreach(var d in data)
                {
                    repo.Cards.Add(d.CreateFlashCard());
                }
                
                repo.SaveChanges();
                return Response.AsJson(new Status(1,"OK",$"Added {data.Count} items"));
            };

            Get["/GetData"] = _ => Response.AsJson(repo.Cards.ToArray());

            Get["/GetData/{from}/{to}"] = parameters =>
            {
                int from = parameters.from;
                int to = parameters.to;
                try
                {
                    return Response.AsJson(repo.Cards.OrderBy(o=>o.Word).Skip(from).Take(to).ToArray());
                }
                catch(Exception ex)
                {
                    return Response.AsJson(new Status(0, "Exception during retrieval of data", ex.ToString()));
                }
            };
        }
    }
}