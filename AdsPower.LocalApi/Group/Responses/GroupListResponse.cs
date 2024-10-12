using System.Text.Json.Serialization;
using AdsPower.LocalApi.Group.Models;
using AdsPower.LocalApi.Internal;
using AdsPower.LocalApi.Shared;

namespace AdsPower.LocalApi.Group.Responses;

public record GroupListResponse : LocalApiResponse<GroupList>
{
    [JsonConverter(typeof(EmptyObjectToNullConverter<GroupList>))]
    public override GroupList? Data { get; init; }
}