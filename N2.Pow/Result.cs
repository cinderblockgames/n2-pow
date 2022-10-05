namespace N2.Pow;

public class Result
{
    public WorkResult? WorkResult { get; }
    public ErrorResult? ErrorResult { get; }

    internal Result(WorkResult? result)
    {
        if (result != null)
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
        ErrorResult = result ?? ErrorResult.UnknownError;
    }
}