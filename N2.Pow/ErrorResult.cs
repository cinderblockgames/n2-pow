namespace N2.Pow;

#nullable disable

public class ErrorResult
{
    public int Error { get; set; }
    public string Message { get; set; }
    public string Docs { get; }

    internal static readonly ErrorResult UnknownError = new ErrorResult
    {
        Error = 500,
        Message = "Unable to read response from server."
    };
}