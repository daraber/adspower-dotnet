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
    /// The new name of the profile, no more than 100 characters.
    /// </summary>
    public string? Name { get; init; }

    /// <summary>
    /// Domain name of the user's account platform (e.g., facebook.com, amazon.com).
    /// </summary>
    public string? DomainName { get; init; }

    /// <summary>
    /// A list of URLs to open when launching the browser.
    /// If left empty, the domain name URL will be opened.
    /// </summary>
    public string[]? OpenUrls { get; init; }

    /// <summary>
    /// Username for logging into the account. At least one of username/password or cookie information is required.
    /// </summary>
    public string? Username { get; init; }

    /// <summary>
    /// Password for logging into the account. At least one of username/password or cookie information is required.
    /// </summary>
    public string? Password { get; init; }

    /// <summary>
    /// 2FA key for accounts that require two-factor authentication. 
    /// This key can be used in an online 2FA code generator or similar authenticator.
    /// </summary>
    public string? Fakey { get; init; }

    /// <summary>
    /// Cookie information for the account. At least one of username/password or cookie information is required.
    /// </summary>
    public List<CookieInfo>? Cookie { get; init; }

    /// <summary>
    /// Whether to filter invalid cookies when verification fails.
    /// 0: Return invalid cookies (default); 1: Filter out invalid cookies.
    /// Requires version 2.4.6.6 or above.
    /// </summary>
    public int IgnoreCookieError { get; init; } = 0;

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