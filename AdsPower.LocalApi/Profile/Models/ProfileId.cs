using System.Text.Json.Serialization;

namespace AdsPower.LocalApi.Profile.Models;

public class ProfileId
{
    [JsonPropertyName("id")] public required string Id { get; init; }
}