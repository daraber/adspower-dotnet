using System.Text.Json.Serialization;

namespace AdsPower.LocalApi.Shared;

public record LocalApiList<T>
{
    [JsonPropertyName("list")] public IReadOnlyList<T> List { get; init; } = [];
}