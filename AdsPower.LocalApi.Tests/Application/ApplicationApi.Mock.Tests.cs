using AdsPower.LocalApi.Application;
using AdsPower.LocalApi.Application.Requests;
using AdsPower.LocalApi.Application.Responses;
using AdsPower.LocalApi.Shared;
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

        var responseData = new
        {
            list = new[]
            {
                new
                {
                    id = "id-1",
                    name = "name-1",
                    remark = "name-1"
                },
                new
                {
                    id = "id-2",
                    name = "name-2",
                    remark = "name-2"
                }
            },
            page = 1,
            page_size = 10
        };

        var resultData = await MockSuccessResponse<
            ListApplicationsRequest,
            ApplicationListResponse,
            LocalApiList<LocalApi.Application.Models.Application>
        >(
            "/api/v1/application/list",
            apiClient => apiClient.Application.ListAsync,
            request,
            responseData
        );

        var list = resultData.List;

        Assert.Multiple(() =>
        {
            Assert.That(list, Is.Not.Null.Or.Empty);
            Assert.That(list, Has.Count.EqualTo(2));
            Assert.That(list[0].Id, Is.EqualTo("id-1"));
            Assert.That(list[0].Name, Is.EqualTo("name-1"));
            Assert.That(list[0].Remark, Is.EqualTo("name-1"));
            Assert.That(list[1].Id, Is.EqualTo("id-2"));
            Assert.That(list[1].Name, Is.EqualTo("name-2"));
            Assert.That(list[1].Remark, Is.EqualTo("name-2"));
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