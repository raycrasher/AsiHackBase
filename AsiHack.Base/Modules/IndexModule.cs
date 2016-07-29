using Nancy;

namespace AsiHack.Base.Modules
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = _ =>
            {
                return View["../index"];
            };
        }
    }
}