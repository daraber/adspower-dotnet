using System.Text.Json.Serialization;

namespace AdsPower.LocalApi.Shared;

public record LocalApiResponse
{
    [JsonPropertyName("code")] public required int Code { get; init; }
    [JsonPropertyName("msg")] public required string Message { get; init; }
}

public abstract record LocalApiResponse<T> where T : class
{
    [JsonPropertyName("code")] public required int Code { get; init; }
    [JsonPropertyName("msg")] public required string Message { get; init; }
    
    [JsonPropertyName("data")]
    public abstract T? Data { get; init; }
}