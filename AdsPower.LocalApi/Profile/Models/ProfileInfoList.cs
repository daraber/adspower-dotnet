using System.Text.Json.Serialization;

namespace AdsPower.LocalApi.Profile.Models;

public record ProfileInfoList
{
    [JsonPropertyName("list")] public required List<ProfileInfo> Profiles { get; init; }
}