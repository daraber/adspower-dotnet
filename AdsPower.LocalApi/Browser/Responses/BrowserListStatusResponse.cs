using System.Text.Json.Serialization;
using AdsPower.LocalApi.Browser.Models;
using AdsPower.LocalApi.Internal;
using AdsPower.LocalApi.Shared;

namespace AdsPower.LocalApi.Browser.Responses;

public record BrowserStatusListResponse : LocalApiResponse<BrowserStatusList>
{
    [JsonConverter(typeof(EmptyObjectToNullConverter<BrowserStatusList>))]
    public override BrowserStatusList? Data { get; init; }
}