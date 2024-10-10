using System.Text.Json.Serialization;
using AdsPower.LocalApi.Internal;
using AdsPower.LocalApi.Models;

namespace AdsPower.LocalApi.Responses;

public record StartBrowserResponse : LocalApiResponse
{
    [JsonConverter(typeof(EmptyObjectToNullConverter<BrowserData>))]
    public BrowserData? Data { get; init; }
}