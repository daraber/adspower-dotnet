namespace AdsPower.LocalApi.Profile.Requests;

/// <summary>
/// Represents the request parameters for moving profiles to a different group.
/// </summary>
public record RegroupProfilesRequest
{
    /// <summary>
    /// List of user IDs to be regrouped. This is a required parameter.
    /// </summary>
    public List<string> UserIds { get; init; }

    /// <summary>
    /// The ID of the group to which the profiles will be moved. This is a required parameter.
    /// </summary>
    public string GroupId { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="RegroupProfilesRequest"/> class.
    /// </summary>
    /// <param name="userIds">List of user IDs to be regrouped.</param>
    /// <param name="groupId">The ID of the target group.</param>
    public RegroupProfilesRequest(List<string> userIds, string groupId)
    {
        if (userIds == null || userIds.Count == 0 || userIds.Count > 100)
        {
            throw new ArgumentException("UserIds must contain between 1 and 100 IDs.");
        }

        if (string.IsNullOrWhiteSpace(groupId))
        {
            throw new ArgumentException("GroupId is required.");
        }

        UserIds = userIds;
        GroupId = groupId;
    }
}