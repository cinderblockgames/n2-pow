using System.Net.Http.Headers;

namespace N2.Pow.ConsoleTest;

#nullable disable

public class MessageHandler : DelegatingHandler
{

    public MessageHandler()
        : base(new HttpClientHandler())
    {
        
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var fullRequest = await GetFullMessage(
            request.GetBody(),
            $"{request.Method} {request.RequestUri?.OriginalString}",
            request.Headers,
            request.Content?.Headers
        );
        Console.WriteLine(fullRequest);

        var response = await base.SendAsync(request, cancellationToken);
        var fullResponse = await GetFullMessage(
            response.GetBody(),
            $"{(int)response.StatusCode} {response.StatusCode}",
            response.Headers,
            response.Content.Headers
        );
        Console.WriteLine(fullResponse);

        return response;
    }

    private static async Task<string> GetFullMessage(Task<string> body, string lead, params HttpHeaders[] headers)
    {
        // For some reason, we need to force the Content-Length header for it to be included.
        headers.OfType<HttpContentHeaders>().Select(header => header.ContentLength).ToList();

        var flat = headers.Where(h => h != null).SelectMany(header => header);
        var combined = string.Join(
            Environment.NewLine,
            flat.Select(header => $"{header.Key}: {string.Join(", ", header.Value)}")
        );

        return string.Join(
            $"{Environment.NewLine}{Environment.NewLine}",
            lead,
            combined,
            await body
        );
    }

}