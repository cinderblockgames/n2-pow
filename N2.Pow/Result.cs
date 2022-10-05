namespace N2.Pow;

public class Result
{
    public WorkResult? WorkResult { get; }
    public ErrorResult? ErrorResult { get; }
    public string? OriginalResponse { get; }

    internal Result(WorkResult? result, string? originalResponse)
    {
        OriginalResponse = originalResponse;
        if (result?.Work != null)
        {
            WorkResult = result;
        }
        else
        {
            ErrorResult = ErrorResult.UnknownError;
        }
    }

    internal Result(ErrorResult? result, string? originalResponse)
    {
        OriginalResponse = originalResponse;
        if (result?.Error > 0)
        {
            ErrorResult = result;
        }
        else
        {
            ErrorResult = ErrorResult.UnknownError;
        }
    }
}