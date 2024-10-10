namespace AdsPower.LocalApi.Requests;

/// <summary>
/// Represents the request to update group information, ensuring group name uniqueness.
/// </summary>
public record UpdateGroupRequest : GroupRequest
{
    /// <summary>
    /// The unique ID of the group being edited.
    /// </summary>
    public required string GroupId { get; init; }
}