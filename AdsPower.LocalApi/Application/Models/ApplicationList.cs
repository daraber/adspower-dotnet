using System.Text.Json.Serialization;

namespace AdsPower.LocalApi.Application.Models;

public record ApplicationList
{
    [JsonPropertyName("list")]
    public required List<Application> Applications { get; init; } 
}