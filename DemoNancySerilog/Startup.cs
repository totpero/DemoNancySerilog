using DemoNancySerilog;
using Microsoft.Owin;
using Nancy;
using Owin;

[assembly: IncludeInNancyAssemblyScanning]
[assembly: OwinStartup(typeof(Startup))]
namespace DemoNancySerilog
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            StaticConfiguration.DisableErrorTraces = false;
            app.UseNancy(options =>
                {
                    options.Bootstrapper = new CustomBootstrapper();
                    options.PerformPassThrough = context => context.Response.StatusCode == HttpStatusCode.NotFound;
                }
            );
        }
    }
}