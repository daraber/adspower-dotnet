using System.Text.Json.Serialization;
using AdsPower.LocalApi.Internal;
using AdsPower.LocalApi.Profile.Models;
using AdsPower.LocalApi.Shared;

namespace AdsPower.LocalApi.Profile.Responses;

public record ProfilesListResponse : LocalApiListResponse<ProfileInfo>
{
    [JsonConverter(typeof(EmptyObjectToNullListConverter<ProfileInfo>))]
    public override LocalApiList<ProfileInfo>? Data { get; init; }

    /*
     TODO: Add support properties:
        [JsonPropertyName("page")] public int Page { get; init; }
        [JsonPropertyName("page_size")] public int PageSize { get; init; }
     */
}