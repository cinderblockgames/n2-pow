namespace N2.Pow;

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

    internal WorkResult(
        string difficulty,
        string multiplier,
        string work,
        string frontier,
        int remaining,
        bool cached,
        string duration,
        string server)
    {
        Difficulty = difficulty;
        Multiplier = multiplier;
        Work = work;
        Frontier = frontier;
        Remaining = remaining;
        Cached = cached;
        Duration = duration;
        Server = server;
    }
}