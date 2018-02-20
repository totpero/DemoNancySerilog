using Nancy;
using Nancy.Bootstrapper;
using Nancy.Serilog;
using Nancy.TinyIoc;
using Serilog;

namespace DemoNancySerilog
{
    public class CustomBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            pipelines.EnableSerilog();

            var logger = new LoggerConfiguration()
                .ReadFrom.AppSettings()
                .CreateLogger();
            //Init loger
            Log.Logger = logger;
        }
    }
}