namespace AdsPower.LocalApi.Shared;

public abstract record LocalApiListResponse<T> : LocalApiResponse<LocalApiList<T>>
{
    public abstract override LocalApiList<T>? Data { get; init; }
}