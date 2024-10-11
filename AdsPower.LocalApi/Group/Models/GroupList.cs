using System.Text.Json.Serialization;

namespace AdsPower.LocalApi.Group.Models;

public record GroupList
{
    [JsonPropertyName("list")]
    public required List<Group> Groups { get; init; }
}