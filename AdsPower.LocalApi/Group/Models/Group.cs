using System.Text.Json.Serialization;

namespace AdsPower.LocalApi.Group.Models;

/// <summary>
/// Represents a group with its ID, name, and optional remarks.
/// </summary>
public record Group
{
    /// <summary>
    /// The unique identifier of the group.
    /// </summary>
    [JsonPropertyName("group_id")]
    public required string GroupId { get; init; }

    /// <summary>
    /// The name of the group.
    /// </summary>
    [JsonPropertyName("group_name")]
    public required string GroupName { get; init; }

    /// <summary>
    /// Optional notes or remarks about the group.
    /// </summary>
    [JsonPropertyName("remark")]
    public string? Remark { get; init; }
}