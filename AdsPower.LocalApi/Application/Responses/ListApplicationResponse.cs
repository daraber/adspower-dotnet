using System.Text.Json.Serialization;
using AdsPower.LocalApi.Application.Models;
using AdsPower.LocalApi.Internal;
using AdsPower.LocalApi.Responses;

namespace AdsPower.LocalApi.Application.Responses;

public record ListApplicationResponse : LocalApiResponse<ApplicationList>
{
    [JsonConverter(typeof(EmptyObjectToNullConverter<ApplicationList>))]
    public override ApplicationList? Data { get; init; }
}