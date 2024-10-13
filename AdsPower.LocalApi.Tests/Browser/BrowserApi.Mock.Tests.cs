using AdsPower.LocalApi.Browser;
using AdsPower.LocalApi.Browser.Models;
using AdsPower.LocalApi.Browser.Requests;
using AdsPower.LocalApi.Browser.Responses;
using AdsPower.LocalApi.Shared;
using AdsPower.LocalApi.Tests.Internal;

namespace AdsPower.LocalApi.Tests.Browser;

[TestFixture]
[TestOf(typeof(BrowserApi))]
[Parallelizable(ParallelScope.All)]
[MockTest]
public class BrowserApiMockTests : ApiTestBase
{
    #region StartAsync

    [Test]
    public async Task Start_Success()
    {
        var responseData = new
        {
            ws = new
            {
                selenium = "127.0.0.1:8080",
                puppeteer = "ws://127.0.0.1:xxxx/devtools/browser/xxxxxx"
            },
            debug_port = "xxxx",
            webdriver = @"C:\xxxx\chromedriver.exe"
        };

        var resultData = await MockSuccessResponse<StartBrowserRequest, StartBrowserResponse, BrowserData>(
            "/api/v1/browser/start",
            apiClient => apiClient.Browser.StartAsync,
            new StartBrowserRequest { UserId = "user-id" },
            responseData
        );

        Assert.Multiple(() =>
        {
            Assert.That(resultData.Websockets, Is.Not.Null);
            Assert.That(resultData.Websockets?["selenium"], Is.EqualTo(responseData.ws.selenium));
            Assert.That(resultData.Websockets?["puppeteer"], Is.EqualTo(responseData.ws.puppeteer));
            Assert.That(resultData.DebugPort, Is.EqualTo(responseData.debug_port));
            Assert.That(resultData.WebDriver, Is.EqualTo(responseData.webdriver));
        });
    }

    [Test]
    public async Task Start_Failed() => await MockFailedResponse<StartBrowserRequest, StartBrowserResponse>(
        "/api/v1/browser/start",
        apiClient => apiClient.Browser.StartAsync,
        new StartBrowserRequest { UserId = Guid.NewGuid().ToString() }
    );

    [Test]
    public void Start_Canceled() => TestCancellationToken<StartBrowserRequest, StartBrowserResponse>(
        "api/v1/browser/start",
        apiClient => apiClient.Browser.StartAsync,
        new StartBrowserRequest { UserId = Guid.NewGuid().ToString() }
    );

    #endregion

    #region StopAsync

    [Test]
    public async Task Stop_Success() => await MockSuccessResponse<BrowserRequest, LocalApiResponse>(
        "/api/v1/browser/stop",
        apiClient => apiClient.Browser.StopAsync,
        new BrowserRequest { UserId = Guid.NewGuid().ToString() }
    );

    [Test]
    public async Task Stop_Failed() => await MockFailedResponse<BrowserRequest, LocalApiResponse>(
        "/api/v1/browser/stop",
        apiClient => apiClient.Browser.StopAsync,
        new BrowserRequest { UserId = Guid.NewGuid().ToString() }
    );

    [Test]
    public void Stop_Canceled() => TestCancellationToken<BrowserRequest, LocalApiResponse>(
        "/api/v1/browser/stop",
        apiClient => apiClient.Browser.StopAsync,
        new BrowserRequest { UserId = Guid.NewGuid().ToString() }
    );

    #endregion

    #region GetStatusAsync

    [Test]
    public async Task GetStatus_Success()
    {
        var request = new BrowserRequest { UserId = Guid.NewGuid().ToString() };

        var responseData = new
        {
            status = "Active",
            ws = new
            {
                selenium = "127.0.0.1:xxxx",
                puppeteer = "ws://127.0.0.1:xxxx/devtools/browser/xxxxxx"
            }
        };

        var resultData = await MockSuccessResponse<BrowserRequest, BrowserStatusResponse, BrowserStatus>(
            "/api/v1/browser/active",
            apiClient => apiClient.Browser.GetStatusAsync,
            request,
            responseData
        );

        Assert.Multiple(() =>
        {
            Assert.That(resultData.Status, Is.EqualTo(responseData.status));
            Assert.That(resultData.Websockets, Is.Not.Null);
            Assert.That(resultData.Websockets?["selenium"], Is.EqualTo(responseData.ws.selenium));
            Assert.That(resultData.Websockets?["puppeteer"], Is.EqualTo(responseData.ws.puppeteer));
        });
    }

    [Test]
    public async Task GetStatus_Failed() => await MockFailedResponse<BrowserRequest, BrowserStatusResponse>(
        "/api/v1/browser/active",
        apiClient => apiClient.Browser.GetStatusAsync,
        new BrowserRequest { UserId = Guid.NewGuid().ToString() }
    );

    [Test]
    public void GetStatus_Canceled() => TestCancellationToken<BrowserRequest, BrowserStatusResponse>(
        "/api/v1/browser/active",
        apiClient => apiClient.Browser.GetStatusAsync,
        new BrowserRequest { UserId = Guid.NewGuid().ToString() }
    );

    #endregion

    #region GetStatusListAsync

    [Test]
    public async Task GetStatusList_Success()
    {
        var request = new BrowserRequest { UserId = Guid.NewGuid().ToString() };

        var responseList = new
        {
            list = new[]
            {
                new
                {
                    user_id = "xxx",
                    ws = new
                    {
                        puppeteer = "ws://127.0.0.1:xxxx/devtools/browser/xxxxxx",
                        selenium = "127.0.0.1:xxxx"
                    },
                    debug_port = "xxxx",
                    webdriver = "xxxx"
                }
            }
        };

        var resultData = await MockSuccessResponse<BrowserRequest, BrowserStatusListResponse, LocalApiList<UserBrowserData>>(
            "/api/v1/browser/local-active",
            apiClient => apiClient.Browser.GetStatusListAsync,
            request,
            responseList
        );
        
        Assert.Multiple(() =>
        {
            Assert.That(resultData.List, Is.Not.Null.Or.Empty);
            Assert.That(resultData.List, Has.Count.EqualTo(1));
            Assert.That(resultData.List[0].UserId, Is.EqualTo(responseList.list[0].user_id));
            Assert.That(resultData.List[0].Websockets, Is.Not.Null);
            Assert.That(resultData.List[0].Websockets?["selenium"], Is.EqualTo(responseList.list[0].ws.selenium));
            Assert.That(resultData.List[0].Websockets?["puppeteer"], Is.EqualTo(responseList.list[0].ws.puppeteer));
            Assert.That(resultData.List[0].DebugPort, Is.EqualTo(responseList.list[0].debug_port));
            Assert.That(resultData.List[0].WebDriver, Is.EqualTo(responseList.list[0].webdriver));
        });
    }

    [Test]
    public async Task GetStatusList_Failed() => await MockFailedResponse<BrowserRequest, BrowserStatusListResponse>(
        "/api/v1/browser/local-active",
        apiClient => apiClient.Browser.GetStatusListAsync,
        new BrowserRequest { UserId = Guid.NewGuid().ToString() }
    );

    [Test]
    public void GetStatusList_Canceled() => TestCancellationToken<BrowserRequest, BrowserStatusListResponse>(
        "/api/v1/browser/local-active",
        apiClient => apiClient.Browser.GetStatusListAsync,
        new BrowserRequest { UserId = Guid.NewGuid().ToString() }
    );

    #endregion
}