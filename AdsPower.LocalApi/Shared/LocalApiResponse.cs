using System.Text.Json.Serialization;

namespace AdsPower.LocalApi.Shared;

public record LocalApiResponse
{
    [JsonPropertyName("code")] public required int Code { get; init; }
    [JsonPropertyName("msg")] public required string Message { get; init; }
    
    public bool Success => Code == 0;
}

public abstract record LocalApiResponse<T> : LocalApiResponse where T : class
{
    [JsonPropertyName("data")]
    public abstract T? Data { get; init; }
}