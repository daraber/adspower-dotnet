using System.Text.Json.Serialization;
using AdsPower.LocalApi.Internal;
using AdsPower.LocalApi.Shared;

namespace AdsPower.LocalApi.Group.Responses;

public record GroupListResponse : LocalApiListResponse<Models.Group>
{
    [JsonConverter(typeof(EmptyObjectToNullListConverter<Models.Group>))]
    public override LocalApiList<Models.Group>? Data { get; init; }
}