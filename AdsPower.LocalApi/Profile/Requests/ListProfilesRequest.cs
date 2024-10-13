using AdsPower.LocalApi.Shared;

namespace AdsPower.LocalApi.Profile.Requests;

/// <summary>
/// Represents the request parameters for querying profiles.
/// </summary>
public record ListProfilesRequest : IQueryParameterizeable
{
    /// <summary>
    /// Group ID to filter the profiles. Optional.
    /// </summary>
    public int? GroupId { get; init; }

    /// <summary>
    /// User ID to filter by profile ID. Optional.
    /// </summary>
    public string? UserId { get; init; }

    /// <summary>
    /// Serial number to filter the profiles. Optional.
    /// </summary>
    public string? SerialNumber { get; init; }

    /// <summary>
    /// Sorting options for the results. Supports fields: serial_number, last_open_time, created_time, either asc (ascending) or desc (descending). Optional.
    /// </summary>
    public Dictionary<string, string>? UserSort { get; init; }

    /// <summary>
    /// Page number for pagination. Default is 1.
    /// </summary>
    public int Page { get; init; } = 1;

    /// <summary>
    /// Number of results per page. Default is 50, maximum is 100.
    /// </summary>
    public int PageSize { get; init; } = 50;

    public Dictionary<string, string> GetQueryParameters()
    {
        var parameters = new Dictionary<string, string>();

        if (GroupId.HasValue) parameters.Add("group_id", GroupId.Value.ToString());
        if (!string.IsNullOrEmpty(UserId)) parameters.Add("user_id", UserId);
        if (!string.IsNullOrEmpty(SerialNumber)) parameters.Add("serial_number", SerialNumber);
        
        if (UserSort is { Count: > 0 })
        {
            var value = UserSort.Select(x => $"\"{x.Key}\":\"{x.Value}\"");
            parameters.Add("user_sort", "{" + string.Join(",", value) + "}");
        }

        parameters.Add("page", Page.ToString());
        parameters.Add("page_size", PageSize.ToString());

        return parameters;
    }
}