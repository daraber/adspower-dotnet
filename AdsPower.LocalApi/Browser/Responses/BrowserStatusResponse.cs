using System.Text.Json.Serialization;
using AdsPower.LocalApi.Browser.Models;
using AdsPower.LocalApi.Internal;
using AdsPower.LocalApi.Responses;

namespace AdsPower.LocalApi.Browser.Responses;

public record BrowserStatusResponse : LocalApiResponse<BrowserStatus>
{
    [JsonConverter(typeof(EmptyObjectToNullConverter<BrowserStatus>))]
    public override BrowserStatus? Data { get; init; }
}