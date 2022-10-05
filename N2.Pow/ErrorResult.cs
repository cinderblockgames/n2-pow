namespace N2.Pow;

public class ErrorResult
{
    public int Error { get; }
    public string Message { get; }
    public string? Docs { get; }

    internal ErrorResult(int error, string message, string? docs)
    {
        Error = error;
        Message = message;
        Docs = docs;
    }

    internal static readonly ErrorResult UnknownError = new ErrorResult(
        500,
        "Unable to read response from server.",
        null
    );
}