using AdsPower.LocalApi.Requests;

namespace AdsPower.LocalApi.Tests;

[TestFixture]
[TestOf(typeof(BrowserApi))]
[Parallelizable(ParallelScope.All)]
[Category("Mock")]
public class BrowserApiTests : ApiTestBase
{
    [Test]
    public async Task Start_Success()
    {
        var content = new
        {
            code = 0,
            data = new
            {
                ws = new
                {
                    selenium = "127.0.0.1:8080",
                    puppeteer = "ws://127.0.0.1:xxxx/devtools/browser/xxxxxx"
                },
                debug_port = "xxxx",
                webdriver = @"C:\xxxx\chromedriver.exe"
            },
            msg = "success"
        };

        using var apiClient = CreateMockClient("api/v1/browser/start", content);
        var browserApi = apiClient.Browser;

        var request = new StartBrowserRequest { UserId = Guid.NewGuid().ToString() };
        var result = await browserApi.StartAsync(request);

        Assert.Multiple(() =>
        {
            Assert.That(result.Code, Is.EqualTo(content.code));
            Assert.That(result.Message, Is.EqualTo(content.msg));

            Assert.That(result.Data, Is.Not.Null);
            Assert.That(result.Data?.DebugPort, Is.EqualTo(content.data.debug_port));
            Assert.That(result.Data?.WebDriver, Is.EqualTo(content.data.webdriver));

            Assert.That(result.Data?.Websockets, Is.Not.Null
                .And.Count.EqualTo(2)
                .And.ContainKey("selenium")
                .And.ContainKey("puppeteer"));
        });
    }

    [Test]
    public async Task Start_Failed()
    {
        var content = new
        {
            code = -1,
            data = new { },
            msg = "failed"
        };

        using var apiClient = CreateMockClient("api/v1/browser/start", content);
        var browserApi = apiClient.Browser;

        var request = new StartBrowserRequest
        {
            UserId = "xxxx"
        };

        var result = await browserApi.StartAsync(request);

        Assert.Multiple(() =>
        {
            Assert.That(result.Code, Is.EqualTo(content.code));
            Assert.That(result.Data, Is.Null);
            Assert.That(result.Message, Is.EqualTo(content.msg));
        });
    }
}