using System.Text.Json.Serialization;
using AdsPower.LocalApi.Internal;

namespace AdsPower.LocalApi.Shared;

public record LocalApiListResponse<T> : LocalApiResponse<LocalApiList<T>>
{
    [JsonConverter(typeof(EmptyObjectToNullConverter))]
    public override LocalApiList<T>? Data { get; init; }
}

public record LocalApiList<T>
{
    
}