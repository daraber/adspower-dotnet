using AdsPower.LocalApi.Models;

namespace AdsPower.LocalApi.Requests;

/// <summary>
/// Represents the common properties for creating or managing profiles.
/// </summary>
public record ProfileRequest
{
    /// <summary>
    /// The name of the account, no more than 100 characters.
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
    /// Account deduplication settings. Defaults to allowing duplication.
    /// 0: Allow duplication; 2: Deduplication based on account name/password;
    /// 3: Deduplication based on cookie; 4: Deduplication based on c_user (specific to Facebook).
    /// </summary>
    public int[]? RepeatConfig { get; init; }

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
    /// Notes or remarks about the account.
    /// </summary>
    public string? Remark { get; init; }
}
