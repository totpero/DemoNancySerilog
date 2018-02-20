#addin Cake.Curl

var target = Argument("target", "Default");

Task("Default")
  .Does(() =>
{
  Information("Start deploing...");

	var address = new Uri("http://localhost:60628/sync");
	UploadFile(address, "test.zip");
});

RunTarget(target);