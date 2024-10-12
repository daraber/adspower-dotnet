namespace AdsPower.LocalApi.Internal;

public interface IQueryParameterizeable
{
    public Dictionary<string, string> GetQueryParameters();
}

