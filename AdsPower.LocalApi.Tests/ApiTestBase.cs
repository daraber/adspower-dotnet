using System.Text.Json;
using RichardSzalay.MockHttp;

namespace AdsPower.LocalApi.Tests;

public abstract class ApiTestBase
{
    private const string Url = "http://localhost";

    protected LocalApiClient CreateMockClient(string endpoint, object content)
    {
        var contentString = JsonSerializer.Serialize(content);

        var mockHttp = new MockHttpMessageHandler();

        mockHttp.When($"{Url}/{endpoint}")
            .Respond("application/json", contentString);
        
        return new LocalApiClient(Url, mockHttp);
    }
}