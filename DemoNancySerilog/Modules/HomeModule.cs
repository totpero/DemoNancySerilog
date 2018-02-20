using System;
using System.IO;
using System.Linq;
using Nancy;
using Nancy.Responses;
using Serilog;

namespace DemoNancySerilog.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule(IRootPathProvider pathProvider)
        {
            Before += ctx => !ctx.Request.Files.Any() ? new TextResponse(HttpStatusCode.BadRequest, "Not Found") : null;

            Get["/"] = _ => new TextResponse(HttpStatusCode.BadRequest, "Not Found");

            Post["/sync"] = x =>
            {
                var file = Request.Files.FirstOrDefault();

                if (file == null) return Response.AsText("error");
                try
                {
                    using (var output = new FileStream(@"D:\MyOutput.zip", FileMode.Create))
                    {
                        file.Value.CopyTo(output);
                    }

                }
                catch (Exception e)
                {
                    Log.Error(e, "Eroare: ");
                    throw;
                }
                return Response.AsText("ok");
            };
        }
    }
}