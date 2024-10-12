namespace AdsPower.LocalApi.Profile.Models;


/// <summary>
/// Represents detailed information about a single cookie.
/// </summary>
public record CookieInfo
{
    /// <summary>
    /// Gets the domain associated with the cookie.
    /// </summary>
    public string Domain { get; init; } = string.Empty;

    /// <summary>
    /// Gets the path associated with the cookie.
    /// </summary>
    public string Path { get; init; } = "/";

    /// <summary>
    /// Gets the SameSite attribute of the cookie, indicating the same-site policy.
    /// </summary>
    public string SameSite { get; init; } = "unspecified";

    /// <summary>
    /// Gets a value indicating whether the cookie is secure.
    /// </summary>
    public bool Secure { get; init; } = true;

    /// <summary>
    /// Gets the value of the cookie.
    /// </summary>
    public string Value { get; init; } = string.Empty;

    /// <summary>
    /// Gets the unique identifier of the cookie.
    /// </summary>
    public int Id { get; init; }
}