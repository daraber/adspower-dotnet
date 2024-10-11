using System.Text.Json.Serialization;

namespace AdsPower.LocalApi.Browser.Models;

/// <summary>
/// Represents a list of browser statuses.
/// </summary>
public record BrowserStatusList
{
    [JsonPropertyName("list")] public required List<UserBrowserData> Browsers { get; init; }
}