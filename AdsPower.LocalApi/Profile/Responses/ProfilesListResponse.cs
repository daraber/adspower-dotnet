using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using AdsPower.LocalApi.Internal;
using AdsPower.LocalApi.Profile.Models;
using AdsPower.LocalApi.Shared;

namespace AdsPower.LocalApi.Profile.Responses;

public record ProfilesListResponse : LocalApiResponse<ProfileDataList>
{
    [JsonConverter(typeof(EmptyObjectToNullConverter<ProfileDataList>))]
    public override ProfileDataList? Data { get; init; }
    
    [MemberNotNullWhen(true, nameof(Data))]
    public override bool Success => base.Success;
}