using AdsPower.LocalApi.Application;
using AdsPower.LocalApi.Application.Requests;
using AdsPower.LocalApi.Application.Responses;
using AdsPower.LocalApi.Tests.Internal;

namespace AdsPower.LocalApi.Tests.Application;

[TestFixture]
[TestOf(typeof(ApplicationApi))]
[Parallelizable(ParallelScope.All)]
[MockTest]
public class ApplicationApiMockTests : ApiTestBase
{
    [Test]
    public async Task GetCategoryList_Success()
    {
        var request = new ListApplicationsRequest();

        var response = new
        {
            code = 0,
            msg = "Success",
            data = new
            {
                list = new[]
                {
                    new
                    {
                        id = "XXX",
                        name = "XXX",
                        remark = "XXX"
                    }
                },
                page = 1,
                page_size = 10
            }
        };

        var result = await MockResponse<ListApplicationsRequest, ApplicationListResponse>(
            "/api/v1/application/list",
            apiClient => apiClient.Application.ListAsync,
            request,
            response
        );

        Assert.Multiple(() =>
        {
            Assert.That(result.Code, Is.EqualTo(response.code));
            Assert.That(result.Message, Is.EqualTo(response.msg));
            Assert.That(result.Data, Is.Not.Null);
            Assert.That(result.Data?.Applications, Is.Not.Null);
            Assert.That(result.Data?.Applications.Count, Is.EqualTo(1));
        });

        var category = result.Data?.Applications[0];
        var expectedCategory = response.data.list[0];

        Assert.Multiple(() =>
        {
            Assert.That(category?.Id, Is.EqualTo(expectedCategory.id));
            Assert.That(category?.Name, Is.EqualTo(expectedCategory.name));
            Assert.That(category?.Remark, Is.EqualTo(expectedCategory.remark));
        });
    }

    [Test]
    public async Task GetCategoryList_Failed()
    {
        var request = new ListApplicationsRequest();

        var response = new
        {
            code = -1,
            data = new { },
            msg = "failed"
        };

        var result = await MockResponse<ListApplicationsRequest, ApplicationListResponse>(
            "/api/v1/application/list",
            apiClient => apiClient.Application.ListAsync,
            request,
            response
        );

        Assert.Multiple(() =>
        {
            Assert.That(result.Code, Is.EqualTo(response.code));
            Assert.That(result.Message, Is.EqualTo(response.msg));
            Assert.That(result.Data, Is.Null);
        });
    }

    [Test]
    public void GetCategoryList_Canceled()
    {
        var request = new ListApplicationsRequest();

        var response = new
        {
            code = -1,
            data = new { },
            msg = "failed"
        };

        TestCancellationToken<ListApplicationsRequest, ApplicationListResponse>(
            "/api/v1/application/list",
            apiClient => apiClient.Application.ListAsync,
            request,
            response
        );
    }
}