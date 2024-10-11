using System.Text.Json.Serialization;

namespace AdsPower.LocalApi.Group.Models;

public record Group
{
    [JsonPropertyName("group_id")] public string GroupId { get; init; } = string.Empty;
    [JsonPropertyName("group_name")] public string GroupName { get; init; } = string.Empty;
    [JsonPropertyName("remark")] public string? Remark { get; init; }
}