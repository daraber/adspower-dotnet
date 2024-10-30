using System.Text.Json.Serialization;

namespace AdsPower.LocalApi.Group.Requests;

/// <summary>
/// Represents the request to update group information, ensuring group name uniqueness.
/// </summary>
public record UpdateGroupRequest : GroupRequest
{
    /// <summary>
    /// The unique ID of the group being edited.
    /// </summary>
    [JsonPropertyName("group_id")]
    public required string GroupId { get; init; }
    
}