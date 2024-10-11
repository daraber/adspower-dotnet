namespace AdsPower.LocalApi.Internal;

internal interface IQueryParameterizeable
{
    public Dictionary<string, string> GetQueryParameters();
}

