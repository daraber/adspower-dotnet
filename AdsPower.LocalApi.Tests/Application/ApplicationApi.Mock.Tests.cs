using AdsPower.LocalApi.Application;
using AdsPower.LocalApi.Application.Requests;
using AdsPower.LocalApi.Application.Responses;
using AdsPower.LocalApi.Tests.Internal;

namespace AdsPower.LocalApi.Tests.Application;

[TestFixture]
[TestOf(typeof(ApplicationApi))]
[Parallelizable(ParallelScope.All)]
[MockTest]
public class ApplicationApiTests : ApiTestBase
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
            Assert.That(result.Data?.List, Is.Not.Null);
            Assert.That(result.Data?.List.Count, Is.EqualTo(response.data.list.Length));
        });

        var category = result.Data?.List.First();
        var expectedCategory = response.data.list.First();

        Assert.Multiple(() =>
        {
            Assert.That(category, Is.Not.Null);
            Assert.That(category?.Id, Is.EqualTo(expectedCategory.id));
            Assert.That(category?.Name, Is.EqualTo(expectedCategory.name));
            Assert.That(category?.Remark, Is.EqualTo(expectedCategory.remark));
        });
    }

    [Test]
    public async Task GetCategoryList_Failed()
    {
        await MockFailedResponse<ListApplicationsRequest, ApplicationListResponse>(
            "/api/v1/application/list",
            apiClient => apiClient.Application.ListAsync,
            new ListApplicationsRequest()
        );
    }

    [Test]
    public void GetCategoryList_Canceled()
    {
        TestCancellationToken<ListApplicationsRequest, ApplicationListResponse>(
            "/api/v1/application/list",
            apiClient => apiClient.Application.ListAsync,
            new ListApplicationsRequest()
        );
    }
}