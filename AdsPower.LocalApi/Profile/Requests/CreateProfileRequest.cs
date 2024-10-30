using System.Text.Json.Serialization;
using AdsPower.LocalApi.Profile.Models;

namespace AdsPower.LocalApi.Profile.Requests;
/// <summary>
/// Represents the request to create a new browser profile with configuration options.
/// </summary>
public record CreateProfileRequest : ProfileRequest
{
    /// <summary>
    /// The group ID to which this profile will be assigned.
    /// </summary>
    [JsonPropertyName("group_id")]
    public required string GroupId { get; init; }

    /// <summary>
    /// The proxy IP used for account login (for lumauto or oxylabs proxies).
    /// </summary>
    [JsonPropertyName("ip")]
    public string? Ip { get; init; }

    /// <summary>
    /// Country or region associated with the proxy IP (required for lumauto or oxylabs).
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
    /// The IP checker service to use, such as ip2location or ipapi. Requires version 2.6.3.8 or above.
    /// </summary>
    [JsonPropertyName("ip_checker")]
    public string? IpChecker { get; init; }

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
    public required FingerprintConfig FingerprintConfig { get; init; }
}