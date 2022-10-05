namespace N2.Pow;

#nullable disable

public class WorkResult
{
    public string Difficulty { get; set; }
    public string Multiplier { get; set; }
    public string Work { get; set; }
    public string Frontier { get; set; }
    public int Remaining { get; set; }
    public bool Cached { get; set; }
    public string Duration { get; set; }
    public string Server { get; set; }
}