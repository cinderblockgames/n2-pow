namespace N2.Pow;

public class WorkServerOptions
{
    public string? ApiKey { get; set; } = null;
    public bool Post { get; set; } = false;
    public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(5);
    public string Url { get; set; } = "https://pow.nano.to";
}