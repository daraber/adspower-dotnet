namespace AdsPower.LocalApi.Profile.Requests;

/// <summary>
/// Represents the request parameters for moving profiles to a different group.
/// </summary>
public record RegroupProfilesRequest
{
    /// <summary>
    /// List of user IDs to be regrouped. This is a required parameter.
    /// </summary>
    public required List<string> UserIds { get; init; }

    /// <summary>
    /// The ID of the group to which the profiles will be moved. This is a required parameter.
    /// </summary>
    public required string GroupId { get; init; }
}