using System.Text.Json.Serialization;

namespace AdsPower.LocalApi.Models;

public record BrowserData
{
    [JsonPropertyName("ws")]
    public Dictionary<string, string>? Websockets { get; init; }
    
    [JsonPropertyName("debug_port")]
    public required string DebugPort { get; init; }
    
    [JsonPropertyName("webdriver")]
    public required string WebDriver { get; init; }
}