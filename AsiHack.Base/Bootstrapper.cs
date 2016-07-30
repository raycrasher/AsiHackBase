namespace AsiHack.Base
{
    using Nancy;
    using Nancy.Bootstrapper;
    using Nancy.Conventions;
    using Nancy.TinyIoc;
    using Nancy.Authentication.Forms;
    using Services;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        // The bootstrapper enables you to reconfigure the composition of the framework,
        // by overriding the various methods and properties.
        // For more information https://github.com/NancyFx/Nancy/wiki/Bootstrapper

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            var formsAuthConfiguration =
                new FormsAuthenticationConfiguration()
                {
                    RedirectUrl = "/",
                    UserMapper = container.Resolve<IUserMapper>(),
                };
            FormsAuthentication.Enable(pipelines, formsAuthConfiguration);
            SimpleIoc.Default.Register<Repository>();
        }

        protected override void ConfigureConventions(NancyConventions conventions)
        {
            base.ConfigureConventions(conventions);
            conventions.StaticContentsConventions.Add(
                StaticContentConventionBuilder.AddDirectory("assets", "/Assets")
            );

            conventions.StaticContentsConventions.Add(
                StaticContentConventionBuilder.AddFile("/index.html", "/Views/index.html")
            );

            conventions.StaticContentsConventions.Add(
                StaticContentConventionBuilder.AddDirectory("script", "/Script")
            );


        }
    }
}