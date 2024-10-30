using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using AdsPower.LocalApi.Internal;
using AdsPower.LocalApi.Profile.Models;
using AdsPower.LocalApi.Shared;

namespace AdsPower.LocalApi.Profile.Responses;

public record CreateProfileResponse : LocalApiResponse<ProfileId>
{
    [JsonConverter(typeof(EmptyObjectToNullConverter<ProfileId>))]
    public override ProfileId? Data { get; init; }
    
    [MemberNotNullWhen(true, nameof(Data))]
    public override bool Success => base.Success;
}