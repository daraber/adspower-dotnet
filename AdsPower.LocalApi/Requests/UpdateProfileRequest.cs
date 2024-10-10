using AdsPower.LocalApi.Models;

namespace AdsPower.LocalApi.Requests;

/// <summary>
/// Represents the request to update an existing browser profile with configuration options.
/// </summary>
public record UpdateProfileRequest : ProfileRequest
{
    /// <summary>
    /// The profile ID of the profile that needs to be edited.
    /// </summary>
    public required string UserId { get; init; }

    /// <summary>
    /// Proxy IP used for account login (required when using lumauto or oxylabs proxies).
    /// </summary>
    public string? Ip { get; init; }

    /// <summary>
    /// Country or region associated with the account.
    /// Without lumauto or oxylabs IP, this field is required.
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
    /// Notes or remarks about the account.
    /// </summary>
    public string? Remark { get; init; }

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
    public FingerprintConfig? FingerprintConfig { get; init; }
}