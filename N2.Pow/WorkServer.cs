using System.Net.Http.Json;
using System.Text.Json;

namespace N2.Pow;

public class WorkServer
{
    private HttpClient Client { get; }
    private WorkServerOptions Options { get; }

    public WorkServer(WorkServerOptions? options = null, HttpMessageHandler? handler = null)
    {
        Options = options ?? new();

        Client = handler != null ? new HttpClient(handler) : new HttpClient();
        Client.BaseAddress = new Uri(Options.Url);
        Client.Timeout = Options.Timeout;
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
        return await Deserialize(Client.GetAsync(path));
    }

    private async Task<Result> GenerateWorkPost(string hash)
    {
        var request = new WorkRequest(hash, Options.ApiKey);
        return await Deserialize(Client.PostAsJsonAsync(null as string, request));
    }

    private static readonly JsonSerializerOptions SerializerOptions =
        new JsonSerializerOptions(JsonSerializerDefaults.Web);

    private async Task<Result> Deserialize(Task<HttpResponseMessage> result)
    {
        try
        {
            HttpResponseMessage message = await result;
            var json = await message.Content.ReadAsStringAsync();
            var work = JsonSerializer.Deserialize<WorkResult>(json, SerializerOptions);
            return work?.Work != null
                ? new Result(work)
                : new Result(JsonSerializer.Deserialize<ErrorResult>(json, SerializerOptions));
        }
        catch (Exception ex)
        {
            return new Result(new ErrorResult { Error = 500, Message = ex.Message });
        }
    }
}