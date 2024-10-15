using System.Text.Json.Serialization;
using AdsPower.LocalApi.Internal;
using AdsPower.LocalApi.Profile.Models;
using AdsPower.LocalApi.Shared;

namespace AdsPower.LocalApi.Profile.Responses;

public record ProfilesListResponse : LocalApiListResponse<ProfileData>
{
    [JsonConverter(typeof(EmptyObjectToNullListConverter<ProfileData>))]
    public override LocalApiList<ProfileData>? Data { get; init; }

    /*
     TODO: Add support properties:
        [JsonPropertyName("page")] public int Page { get; init; }
        [JsonPropertyName("page_size")] public int PageSize { get; init; }
     */
}