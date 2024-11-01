using System.Text.Json.Serialization;
using AdsPower.LocalApi.Profile.Models;

namespace AdsPower.LocalApi.Profile.Requests;

/// <summary>
/// Represents the request to update an existing browser profile with configuration options.
/// </summary>
public record UpdateProfileRequest : ProfileRequest
{
    /// <summary>
    /// The profile ID of the profile that needs to be edited.
    /// </summary>
    [JsonPropertyName("user_id")]
    public required string UserId { get; init; }

    /// <summary>
    /// Proxy IP used for account login (required when using lumauto or oxylabs proxies).
    /// </summary>
    [JsonPropertyName("ip")]
    public string? Ip { get; init; }

    /// <summary>
    /// Country or region associated with the account.
    /// Without lumauto or oxylabs IP, this field is required.
    /// </summary>
    [JsonPropertyName("country")]
    public string? Country { get; init; }

    /// <summary>
    /// Optional state or province for account login location.
    /// </summary>
    [JsonPropertyName("region")]
    public string? Region { get; init; }

    /// <summary>
    /// Optional city for account login location.
    /// </summary>
    [JsonPropertyName("city")]
    public string? City { get; init; }

    /// <summary>
    /// Application category ID. Pass 0 to follow team application.
    /// Requires version 2.6.6.5 or above.
    /// </summary>
    [JsonPropertyName("sys_app_cate_id")]
    public int SysAppCateId { get; init; } = 0;

    /// <summary>
    /// Proxy configuration object for account proxy settings.
    /// </summary>
    [JsonPropertyName("user_proxy_config")]
    public UserProxyConfig? UserProxyConfig { get; init; }

    /// <summary>
    /// Proxy ID, or use "random" to randomize a proxy.
    /// </summary>
    [JsonPropertyName("proxy_id")]
    public string? ProxyId { get; init; }

    /// <summary>
    /// Fingerprint configuration object for the account.
    /// </summary>
    [JsonPropertyName("fingerprint_config")]
    public FingerprintConfig? FingerprintConfig { get; init; }
}