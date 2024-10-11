using System.Text.Json.Serialization;
using AdsPower.LocalApi.Internal;
using AdsPower.LocalApi.Responses;

namespace AdsPower.LocalApi.Group.Responses;

public record CreateGroupResponse : LocalApiResponse<Models.Group>
{
    [JsonConverter(typeof(EmptyObjectToNullConverter<Models.Group>))]
    public override Models.Group? Data { get; init; }
}