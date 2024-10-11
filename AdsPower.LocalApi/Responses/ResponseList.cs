using System.Text.Json.Serialization;

namespace AdsPower.LocalApi.Responses;

public class ResponseList<T>
{
    [JsonPropertyName("list")]
    public required List<T> List { get; init; }
}