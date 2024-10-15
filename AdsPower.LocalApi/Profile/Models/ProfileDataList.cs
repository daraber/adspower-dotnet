using System.Text.Json.Serialization;
using AdsPower.LocalApi.Shared;

namespace AdsPower.LocalApi.Profile.Models;

public record ProfileDataList : LocalApiList<ProfileData>
{
    [JsonPropertyName("page")] public int Page { get; init; }
    [JsonPropertyName("page_size")] public int PageSize { get; init; }
}