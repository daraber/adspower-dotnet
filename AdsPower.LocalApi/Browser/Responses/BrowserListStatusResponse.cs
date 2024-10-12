using System.Text.Json.Serialization;
using AdsPower.LocalApi.Browser.Models;
using AdsPower.LocalApi.Internal;
using AdsPower.LocalApi.Shared;

namespace AdsPower.LocalApi.Browser.Responses;

public record BrowserStatusListResponse : LocalApiListResponse<UserBrowserData>
{
    [JsonConverter(typeof(EmptyObjectToNullListConverter<UserBrowserData>))]
    public override LocalApiList<UserBrowserData>? Data { get; init; }
}