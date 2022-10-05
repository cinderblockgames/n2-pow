namespace N2.Pow;

public class Result
{
    public WorkResult? WorkResult { get; }
    public ErrorResult? ErrorResult { get; }

    internal Result(WorkResult? result)
    {
        if (result?.Work != null)
        {
            WorkResult = result;
        }
        else
        {
            ErrorResult = ErrorResult.UnknownError;
        }
    }

    internal Result(ErrorResult? result)
    {
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