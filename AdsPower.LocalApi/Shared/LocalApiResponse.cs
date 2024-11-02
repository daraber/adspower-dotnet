using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace AdsPower.LocalApi.Shared;

public record LocalApiResponse
{
    [JsonPropertyName("code")] public required int Code { get; init; }
    [JsonPropertyName("msg")] public required string Message { get; init; }
    [JsonIgnore] public virtual bool Success => Code == 0;
}

public abstract record LocalApiResponse<T> : LocalApiResponse where T : class
{
    [JsonPropertyName("data")] public abstract T? Data { get; init; }

    [MemberNotNullWhen(true, nameof(Data))]
    public override bool Success => base.Success && Data is not null;
}