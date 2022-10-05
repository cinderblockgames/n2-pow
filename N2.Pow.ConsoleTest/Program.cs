using System.Text.Json;
using N2.Pow;

var server = new WorkServer(
    new WorkServerOptions
    {
        Post = false,
        ApiKey = Environment.GetEnvironmentVariable("ApiKey")
    }
);

var result = await server.GenerateWork("277FD6365DF609D601F18F464926B600B15F6CD705A90E2239F55E9F86E7B38F");
Console.WriteLine(JsonSerializer.Serialize(result));
Console.ReadLine();