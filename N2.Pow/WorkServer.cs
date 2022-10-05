﻿using System.Net.Http.Json;

namespace N2.Pow;

public class WorkServer
{
    private HttpClient Client { get; }
    private WorkServerOptions Options { get; }

    public WorkServer(WorkServerOptions options, HttpMessageHandler? handler = null)
    {
        Client = handler != null ? new HttpClient(handler) : new HttpClient();
        Client.BaseAddress = new Uri(options.Url);
        Client.Timeout = options.Timeout;

        Options = options;
    }

    public async Task<Result> GenerateWork(string hash)
    {
        return Options.Post
            ? await GenerateWorkPost(hash)
            : await GenerateWorkGet(hash);
    }

    private async Task<Result> GenerateWorkGet(string hash)
    {
        var path = Options.ApiKey != null ? $"{hash}?key={Options.ApiKey}" : hash;
        var result = await Client.GetAsync(path);
        return await Deserialize(result);
    }

    private async Task<Result> GenerateWorkPost(string hash)
    {
        var request = new WorkRequest(hash, Options.ApiKey);
        var result = await Client.PostAsJsonAsync(null as string, request);
        return await Deserialize(result);
    }

    private async Task<Result> Deserialize(HttpResponseMessage result)
    {
        return result.IsSuccessStatusCode
            ? new Result(await result.Content.ReadFromJsonAsync<WorkResult>())
            : new Result(await result.Content.ReadFromJsonAsync<ErrorResult>());
    }
}