namespace AdsPower.LocalApi.Responses;

public record StatusResponse(int Code, string Message) : LocalApiResponse(Code, Message);