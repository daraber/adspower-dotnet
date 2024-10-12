using System.Text.Json.Serialization;
using AdsPower.LocalApi.Internal;
using AdsPower.LocalApi.Shared;

namespace AdsPower.LocalApi.Application.Responses;

public record ApplicationListResponse : LocalApiListResponse<Models.Application>
{
    [JsonConverter(typeof(EmptyObjectToNullListConverter<Models.Application>))]
    public override LocalApiList<Models.Application>? Data { get; init; }
}