namespace AdsPower.LocalApi.Requests;

/// <summary>
/// Represents the request parameters for deleting profiles.
/// </summary>
public record DeleteProfileRequest
{
    /// <summary>
    /// List of user IDs to be deleted. This is a required parameter.
    /// </summary>
    public List<string> UserIds { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteProfileRequest"/> class.
    /// </summary>
    /// <param name="userIds">List of user IDs to be deleted.</param>
    public DeleteProfileRequest(List<string> userIds)
    {
        if (userIds == null || userIds.Count == 0 || userIds.Count > 100)
        {
            throw new ArgumentException("UserIds must contain between 1 and 100 IDs.");
        }

        UserIds = userIds;
    }
}