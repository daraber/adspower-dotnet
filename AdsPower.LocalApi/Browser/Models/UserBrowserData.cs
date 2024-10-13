using System.Text.Json.Serialization;

namespace AdsPower.LocalApi.Browser.Models;

/// <summary>
/// Represents the data related to browser automation interfaces.
/// </summary>
public record UserBrowserData : BrowserData
{
    /// <summary>
    /// Unique profile ID, generated after creating the profile. Required parameter.
    /// </summary>
    [JsonPropertyName("user_id")]
    public required string UserId { get; init; }
}