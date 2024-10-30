using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using AdsPower.LocalApi.Internal;
using AdsPower.LocalApi.Shared;

namespace AdsPower.LocalApi.Group.Responses;

public record CreateGroupResponse : LocalApiResponse<Models.Group>
{
    [JsonConverter(typeof(EmptyObjectToNullConverter<Models.Group>))]
    public override Models.Group? Data { get; init; }

    [MemberNotNullWhen(true, nameof(Data))]
    public override bool Success => base.Success;
}