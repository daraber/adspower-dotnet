namespace AdsPower.LocalApi.Profile.Models;

/// <summary>
/// Represents a single cookie's information.
/// </summary>
public record CookieInfo
{
    public string Domain { get; init; } = string.Empty;
    public string Path { get; init; } = "/";
    public string SameSite { get; init; } = "unspecified";
    public bool Secure { get; init; } = true;
    public string Value { get; init; } = string.Empty;
    public int Id { get; init; }
}