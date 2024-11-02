Async AdsPower Local API .NET 8 Client 

### Usage

```csharp
var client = new LocalApiClient("http://localhost:5000");
var response = await client.GetConnectionStatusAsync();

if(!response.Success)
{
    Console.WriteLine(response.Message);
    return;
}

var profiles = await client.Profile.ListAsync();
if (profiles.Success)
{
    foreach (var profile in profiles.Data.List)
    {
        Console.WriteLine(profile);
    } 
}
```

### FAQ
For detailed information about the AdsPower API, refer to the [official AdsPower Local API Documentation](https://localapi-doc-en.adspower.com/).