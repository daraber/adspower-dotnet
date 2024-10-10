namespace AdsPower.LocalApi.Requests;

using System.Text.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the request parameters for querying profiles.
/// </summary>
public record QueryProfileRequest
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
    /// Sorting options for the results. Supports fields: serial_number, last_open_time, created_time.
    /// </summary>
    public Dictionary<string, string>? UserSort { get; init; } =
        new Dictionary<string, string> { { "serial_number", "desc" } };

    /// <summary>
    /// Page number for pagination. Default is 1.
    /// </summary>
    public int Page { get; init; } = 1;

    /// <summary>
    /// Number of results per page. Default is 50, maximum is 100.
    /// </summary>
    public int PageSize { get; init; } = 50;
}