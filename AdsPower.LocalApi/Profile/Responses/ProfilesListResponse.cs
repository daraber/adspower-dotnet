using System.Text.Json.Serialization;
using AdsPower.LocalApi.Internal;
using AdsPower.LocalApi.Profile.Models;
using AdsPower.LocalApi.Shared;

namespace AdsPower.LocalApi.Profile.Responses;

public record ProfilesListResponse : LocalApiResponse<ProfileDataList>
{
    [JsonConverter(typeof(EmptyObjectToNullConverter<ProfileDataList>))]
    public override ProfileDataList? Data { get; init; }
}