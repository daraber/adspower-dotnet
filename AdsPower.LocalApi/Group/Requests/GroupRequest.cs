using System.Text.Json.Serialization;

namespace AdsPower.LocalApi.Group.Requests;

/// <summary>
/// Represents the common properties for a group-related request.
/// </summary>
public record GroupRequest
{
    /// <summary>
    /// Unique name of the group. Required for creation and updating.
    /// </summary>
    [JsonPropertyName("group_name")]
    public required string GroupName { get; init; }

    /// <summary>
    /// Optional notes for the group. Requires version 2.6.7.2 or above.
    /// </summary>
    [JsonPropertyName("remark")] 
    public string? Remark { get; init; }
}