namespace AdsPower.LocalApi.Requests;

public record BrowserRequest
{
    /// <summary>
    /// Unique profile ID, generated after creating the profile. Required parameter.
    /// </summary>
    public required string UserId { get; init; }

    /// <summary>
    /// Optional serial number. Priority will be given to <see cref="UserId"/> if both are provided.
    /// </summary>
    public string? SerialNumber { get; init; }
}