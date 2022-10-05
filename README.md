# n2-pow
.NET library for ease of accessing Nano.to GPU PoW API ([pow.nano.to](https://pow.nano.to)).  Documentation can be found [here](https://docs.nano.to/gpu-pow-api).

## Basic Usage
```csharp
var server = new WorkServer();
var response  = await server.GenerateWork("ha..5h");
var work = response.Work;
```

## Options
```csharp
var options = new WorkServerOptions
{
    Post = true, // default false, uses GET
    ApiKey = "key_...", // default null
    Timeout = TimeSpan.FromSeconds(1), // default 5 seconds
    Url = "https://pow2.nano.to" // default "https://pow.nano.to", unlikely to need to change
};
var server = new WorkServer(options);
var response  = await server.GenerateWork("ha..5h");
var work = response.Work;
```