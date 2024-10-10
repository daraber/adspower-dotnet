using System.Text.Json.Serialization;

namespace AdsPower.LocalApi.Responses;

public record LocalApiResponse
{
    [JsonPropertyName("code")] public required int Code { get; init; }
    [JsonPropertyName("msg")] public required string Message { get; init; }
}