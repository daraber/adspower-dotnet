using AdsPower.LocalApi.Shared;
using AdsPower.LocalApi.Tests.Internal;

namespace AdsPower.LocalApi.Tests;

[TestFixture]
[TestOf(typeof(LocalApiClient))]
[Parallelizable(ParallelScope.All)]
[MockTest]
public class LocalApiClientTests : ApiTestBase
{
    [Test]
    public async Task GetConnectionStatus_Success()
    {
        await TestGetConnectionStatus("status", 0, "success");
    }

    [Test]
    public async Task GetConnectionStatus_Failed()
    {
        await TestGetConnectionStatus("status", -1, "failed");
    }
    
    private async Task TestGetConnectionStatus(string endpoint, int code, string message)
    {
        var response = new
        {
            code,
            msg = message
        };

        var result = await MockResponse<LocalApiResponse>(
            endpoint,
            apiClient => apiClient.GetConnectionStatusAsync,
            response
        );

        Assert.Multiple(() =>
        {
            Assert.That(result.Code, Is.EqualTo(response.code));
            Assert.That(result.Message, Is.EqualTo(response.msg));
        });
    }
}