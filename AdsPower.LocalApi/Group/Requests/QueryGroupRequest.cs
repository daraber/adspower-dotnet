namespace AdsPower.LocalApi.Group.Requests;

/// <summary>
/// Represents the request to query group information, including group ID and group name.
/// </summary>
public record QueryGroupRequest
{
    /// <summary>
    /// Optional group name to search for. If empty, all groups will be retrieved.
    /// </summary>
    public string? GroupName { get; init; }

    /// <summary>
    /// Page number for the query. Defaults to 1.
    /// </summary>
    public int Page { get; init; } = 1;

    /// <summary>
    /// Number of items per page. Defaults to 1, with a maximum of 2000.
    /// </summary>
    public int PageSize { get; init; } = 10;
}