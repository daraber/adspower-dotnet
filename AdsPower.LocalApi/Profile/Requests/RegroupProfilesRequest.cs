using System.Text.Json.Serialization;

namespace AdsPower.LocalApi.Profile.Requests;

/// <summary>
/// Represents the request parameters for moving profiles to a different group.
/// </summary>
public record RegroupProfilesRequest
{
    /// <summary>
    /// List of user IDs to be regrouped. This is a required parameter.
    /// </summary>
    [JsonPropertyName("user_ids")]
    public required List<string> UserIds { get; init; }

    /// <summary>
    /// The ID of the group to which the profiles will be moved to. This is a required parameter.
    /// </summary>
    [JsonPropertyName("group_id")]
    public required string GroupId { get; init; }
}