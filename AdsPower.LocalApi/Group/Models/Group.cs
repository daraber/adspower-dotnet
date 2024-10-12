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
    public string GroupId { get; init; } = string.Empty;

    /// <summary>
    /// The name of the group.
    /// </summary>
    [JsonPropertyName("group_name")]
    public string GroupName { get; init; } = string.Empty;

    /// <summary>
    /// Optional notes or remarks about the group.
    /// </summary>
    [JsonPropertyName("remark")]
    public string? Remark { get; init; }
}