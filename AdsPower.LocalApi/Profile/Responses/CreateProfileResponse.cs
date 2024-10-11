using AdsPower.LocalApi.Shared;

namespace AdsPower.LocalApi.Profile.Responses;

public record CreateProfileResponse : LocalApiResponse
{
    public string ProfileId { get; init; } = string.Empty;
}