using AdsPower.LocalApi.Internal;

namespace AdsPower.LocalApi.Browser.Requests;

/// <summary>
/// Represents the common properties for a browser-related request.
/// </summary>
public record BrowserRequest : IQueryParameterizeable
{
    /// <summary>
    /// Unique profile ID, generated after creating the profile. Required parameter.
    /// </summary>
    public required string UserId { get; init; }

    /// <summary>
    /// Optional serial number. Priority will be given to <see cref="UserId"/> if both are provided.
    /// </summary>
    public string? SerialNumber { get; init; }

    public virtual Dictionary<string, string> GetQueryParameters()
    {
        var parameters = new Dictionary<string, string>
        {
            { "user_id", UserId },
        };

        if (!string.IsNullOrWhiteSpace(SerialNumber))
        {
            parameters.Add("serial_number", SerialNumber);
        }

        return parameters;
    }
}