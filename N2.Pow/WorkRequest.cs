using System.Text.Json;
using System.Text.Json.Serialization;

namespace N2.Pow;

internal class WorkRequest
{
    public string Hash { get; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Key { get; set; }

    public WorkRequest(string hash, string? key)
    {
        Hash = hash;
        Key = key;
    }
}