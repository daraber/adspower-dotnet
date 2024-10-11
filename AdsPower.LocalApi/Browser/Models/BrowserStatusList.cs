using System.Text.Json.Serialization;

namespace AdsPower.LocalApi.Browser.Models;

/// <summary>
/// Represents a list of browser statuses.
/// </summary>
public class BrowserStatusList
{
    [JsonPropertyName("list")] public required List<BrowserData> Browsers { get; init; }
}