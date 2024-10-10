namespace AdsPower.LocalApi.Tests;

[TestFixture]
[TestOf(typeof(LocalApiClient))]
[Parallelizable(ParallelScope.All)]
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
        var content = new { code, msg = message };

        using var apiClient = CreateMockClient(endpoint, content);
        var response = await apiClient.GetConnectionStatus();
        
        Assert.Multiple(() =>
        {
            Assert.That(response.Code, Is.EqualTo(content.code));
            Assert.That(response.Message, Is.EqualTo(message));
        });
    }
}