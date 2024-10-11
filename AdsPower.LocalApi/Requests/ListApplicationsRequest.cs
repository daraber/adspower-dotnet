using AdsPower.LocalApi.Internal;

namespace AdsPower.LocalApi.Requests;

/// <summary>
/// Represents the request to query the list of application categories.
/// </summary>
public record ListApplicationsRequest : IQueryParameterizeable
{
    /// <summary>
    /// Page number for the query. Defaults to 1 (first page).
    /// </summary>
    public int? Page { get; init; }

    /// <summary>
    /// Number of items per page. Defaults to 1, with a maximum of 2000.
    /// </summary>
    public int? PageSize { get; init; }

    public Dictionary<string, string> GetQueryParameters()
    {
        var parameters = new Dictionary<string, string>();
        
        if(Page.HasValue) parameters.Add("page", Page.Value.ToString());
        if(PageSize.HasValue) parameters.Add("page_size", PageSize.Value.ToString());
        
        return parameters;
    }
}