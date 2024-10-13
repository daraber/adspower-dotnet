namespace AdsPower.LocalApi.Profile.Requests;

/// <summary>
/// Represents the request parameters for deleting profiles.
/// </summary>
public record DeleteProfileRequest
{
    /// <summary>
    /// List of user IDs to be deleted. This is a required parameter.
    /// </summary>
    public required List<string> UserIds { get; init; }
}