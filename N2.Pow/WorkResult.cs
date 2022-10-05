namespace N2.Pow;

#nullable disable

public class WorkResult
{
    public string Difficulty { get; }
    public string Multiplier { get; }
    public string Work { get; }
    public string Frontier { get; }
    public int Remaining { get; }
    public bool Cached { get; }
    public string Duration { get; }
    public string Server { get; }
}