namespace AdsPower.LocalApi.Shared;

public interface IQueryParameterizeable
{
    public Dictionary<string, string> GetQueryParameters();
}

