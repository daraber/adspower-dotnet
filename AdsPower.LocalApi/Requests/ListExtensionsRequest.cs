namespace AdsPower.LocalApi.Requests;

/// <summary>
/// Represents the request to query the list of application categories.
/// </summary>
public record ListExtensionsRequest
{
    /// <summary>
    /// Page number for the query. Defaults to 1 (first page).
    /// </summary>
    public int Page { get; init; } = 1;

    /// <summary>
    /// Number of items per page. Defaults to 1, with a maximum of 2000.
    /// </summary>
    public int PageSize { get; init; } = 10;
}