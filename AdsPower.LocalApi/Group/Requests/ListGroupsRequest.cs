using AdsPower.LocalApi.Internal;

namespace AdsPower.LocalApi.Group.Requests;

/// <summary>
/// Represents the request to query group information, including group ID and group name.
/// </summary>
public record ListGroupsRequest : IQueryParameterizeable
{
    /// <summary>
    /// Optional group name to search for. If empty, all groups will be retrieved.
    /// </summary>
    public string? GroupName { get; init; }

    /// <summary>
    /// Page number for the query. Defaults to 1.
    /// </summary>
    public int? Page { get; init; }

    /// <summary>
    /// Number of items per page. Defaults to 1, with a maximum of 2000.
    /// </summary>
    public int? PageSize { get; init; } = 10;


    public Dictionary<string, string> GetQueryParameters()
    {
        var parameters = new Dictionary<string, string>();

        if (!string.IsNullOrWhiteSpace(GroupName)) parameters.Add("group_name", GroupName);
        if (Page.HasValue) parameters.Add("page", Page.Value.ToString());
        if (PageSize.HasValue) parameters.Add("page_size", PageSize.Value.ToString());

        return parameters;
    }
}