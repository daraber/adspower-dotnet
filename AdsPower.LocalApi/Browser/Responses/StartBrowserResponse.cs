using System.Text.Json.Serialization;
using AdsPower.LocalApi.Internal;
using AdsPower.LocalApi.Models;
using AdsPower.LocalApi.Responses;

namespace AdsPower.LocalApi.Browser.Responses;

public record StartBrowserResponse : LocalApiResponse
{
    [JsonConverter(typeof(EmptyObjectToNullConverter<BrowserData>))]
    public BrowserData? Data { get; init; }
}