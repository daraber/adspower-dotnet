using System.Text.Json.Serialization;

namespace AdsPower.LocalApi.Browser.Models;

/// <summary>
/// Represents the data related to browser automation interfaces.
/// </summary>
public record BrowserData
{
    /// <summary>
    /// Gets the websocket connections for automation tools (e.g., Selenium, Puppeteer).
    /// </summary>
    [JsonPropertyName("ws")]
    public Dictionary<string, string>? Websockets { get; init; }

    /// <summary>
    /// Gets the debug port for the browser instance.
    /// </summary>
    [JsonPropertyName("debug_port")]
    public required string DebugPort { get; init; }

    /// <summary>
    /// Gets the file path of the WebDriver executable.
    /// </summary>
    [JsonPropertyName("webdriver")]
    public required string WebDriver { get; init; }
}