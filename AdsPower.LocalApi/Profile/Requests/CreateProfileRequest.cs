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
    public required string GroupId { get; init; }

    /// <summary>
    /// The proxy IP used for account login (for lumauto or oxylabs proxies).
    /// </summary>
    public string? Ip { get; init; }

    /// <summary>
    /// Country or region associated with the proxy IP (required for lumauto or oxylabs).
    /// </summary>
    public string? Country { get; init; }

    /// <summary>
    /// Optional state or province for account login location.
    /// </summary>
    public string? Region { get; init; }

    /// <summary>
    /// Optional city for account login location.
    /// </summary>
    public string? City { get; init; }

    /// <summary>
    /// The IP checker service to use, such as ip2location or ipapi. Requires version 2.6.3.8 or above.
    /// </summary>
    public string? IpChecker { get; init; }

    /// <summary>
    /// Application category ID. Pass 0 to follow team application.
    /// Requires version 2.6.6.5 or above.
    /// </summary>
    public int SysAppCateId { get; init; } = 0;

    /// <summary>
    /// Proxy configuration object for account proxy settings.
    /// </summary>
    public UserProxyConfig? UserProxyConfig { get; init; }

    /// <summary>
    /// Proxy ID, or use "random" to randomize a proxy.
    /// </summary>
    public string? ProxyId { get; init; }

    /// <summary>
    /// Fingerprint configuration object for the account.
    /// </summary>
    public required FingerprintConfig FingerprintConfig { get; init; }
}