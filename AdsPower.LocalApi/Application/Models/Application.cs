namespace AdsPower.LocalApi.Application.Models;

public record Application
{
    /// <summary>
    /// The application category ID.
    /// </summary>
    public required string Id { get; init; }

    /// <summary>
    /// The application category name.
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// Notes or remarks about the account.
    /// </summary>
    public string? Remark { get; init; }
}