using System.Text.Json.Serialization;
using AdsPower.LocalApi.Responses;

namespace AdsPower.LocalApi.Browser.Models;

/// <summary>
/// Represents a list of browser statuses.
/// </summary>
public record BrowserStatusList : LocalApiResponse
{
    [JsonPropertyName("list")] public required List<BrowserData> Browsers { get; init; }
}