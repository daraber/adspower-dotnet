﻿using System.Text.Json.Serialization;
using AdsPower.LocalApi.Browser.Models;
using AdsPower.LocalApi.Responses;

namespace AdsPower.LocalApi.Browser.Responses;

public record BrowserStatusResponse : LocalApiResponse<BrowserStatusList>
{
    [JsonPropertyName("list")]
    public override BrowserStatusList? Data { get; init; }
}