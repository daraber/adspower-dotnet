using System.Text.Json.Serialization;

namespace AdsPower.LocalApi.Browser.Models;

/// <summary>
/// Represents the data related to browser status.
/// </summary>
public record BrowserStatus
{
    /// <summary>
    /// Gets the status of the browser instance.
    /// </summary>
    [JsonPropertyName("status")]
    public required string Status { get; init; }

    /// <summary>
    /// Gets the websocket connections for automation tools (e.g., Selenium, Puppeteer).
    /// </summary>
    [JsonPropertyName("ws")]
    public Dictionary<string, string>? Websockets { get; init; }
}