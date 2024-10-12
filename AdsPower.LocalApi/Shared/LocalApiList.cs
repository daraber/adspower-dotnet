using System.Text.Json.Serialization;

namespace AdsPower.LocalApi.Shared;

public record LocalApiList<T>
{
    [JsonPropertyName("list")] public List<T> List { get; init; } = new();
}