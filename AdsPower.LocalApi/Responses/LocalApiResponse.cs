using System.Text.Json.Serialization;

namespace AdsPower.LocalApi.Responses;

public record LocalApiResponse(
    [property: JsonPropertyName("code")] int Code,
    [property: JsonPropertyName("msg")] string Message
);