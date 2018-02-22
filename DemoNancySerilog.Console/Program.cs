using System;
using System.Net;

namespace DemoNancySerilog.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new WebClient();
            var response = client.UploadFile(new Uri("http://localhost:60628/sync"), "test.zip");
        }
    }
}
