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
            Get["/"] = _ => new TextResponse(HttpStatusCode.BadRequest, "Not Found");

            Post["/sync"] = x =>
            {
                var file = Request.Files.FirstOrDefault();

                if (file == null) return Response.AsText("error");
                try
                {
                    using (var reader = new StreamReader(file.Value))
                    {
                        var fileContent = reader.ReadToEnd();
                        return Response.AsText($"File Contents: \n{fileContent}");
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