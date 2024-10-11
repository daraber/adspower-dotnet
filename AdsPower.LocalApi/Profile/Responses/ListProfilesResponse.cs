using System.Text.Json.Serialization;
using AdsPower.LocalApi.Internal;
using AdsPower.LocalApi.Profile.Models;
using AdsPower.LocalApi.Shared;

namespace AdsPower.LocalApi.Profile.Responses;

public record ListProfilesResponse : LocalApiResponse<ProfileInfoList>
{
    [JsonConverter(typeof(EmptyObjectToNullConverter<ProfileInfoList>))]
    public override ProfileInfoList? Data { get; init; }
}