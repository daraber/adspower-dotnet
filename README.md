AdsPower Local API .NET 8 Client. For detailed information about the AdsPower API, refer to
the [official AdsPower Local API Documentation](https://localapi-doc-en.adspower.com/).

Endpoints:
* [Browser](AdsPower.LocalApi/Browser/IBrowserApi.cs) ([docs](https://localapi-doc-en.adspower.com/docs/browser))
* [Groups](AdsPower.LocalApi/Group/IGroupApi.cs) ([docs](https://localapi-doc-en.adspower.com/docs/groups))
* [Applications](AdsPower.LocalApi/Application/IApplicationApi.cs) ([docs](https://localapi-doc-en.adspower.com/docs/extensions))
* [Profiles](AdsPower.LocalApi/Profile/IProfileApi.cs) ([docs](https://localapi-doc-en.adspower.com/docs/profiles))

### Usage

```csharp
var client = new LocalApiClient("http://localhost:5000");

var connectionResponse = await client.GetConnectionStatusAsync();
if(!connectionResponse.Success)
{
    Console.WriteLine(connectionResponse.Message);
    return;
}

var profilesResponse = await client.Profile.ListAsync();
if (profilesResponse.Success)
{
    foreach (var profile in profilesResponse.Data.List)
    {
        Console.WriteLine(profile);
    } 
}
```
