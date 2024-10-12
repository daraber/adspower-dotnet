using AdsPower.LocalApi.Group;
using AdsPower.LocalApi.Group.Requests;
using AdsPower.LocalApi.Group.Responses;
using AdsPower.LocalApi.Tests.Internal;

namespace AdsPower.LocalApi.Tests.Group;

[TestFixture]
[TestOf(typeof(GroupApi))]
[Parallelizable(ParallelScope.All)]
[MockTest]
public class GroupApiMockTests : ApiTestBase
{
    [Test]
    public async Task Create_Success()
    {
        var request = new GroupRequest { GroupName = Guid.NewGuid().ToString() };

        var response = new
        {
            code = 0,
            msg = "Success",
            data = new
            {
                group_id = "group-id",
                group_name = "group-name",
                remark = "group-remark"
            },
        };

        var result = await MockResponse<GroupRequest, CreateGroupResponse>(
            "/api/v1/group/create",
            apiClient => apiClient.Group.CreateAsync,
            request,
            response
        );

        Assert.Multiple(() =>
        {
            Assert.That(result.Code, Is.EqualTo(response.code));
            Assert.That(result.Message, Is.EqualTo(response.msg));
            Assert.That(result.Data, Is.Not.Null);
            Assert.That(result.Data?.GroupId, Is.EqualTo(response.data.group_id));
            Assert.That(result.Data?.GroupName, Is.EqualTo(response.data.group_name));
            Assert.That(result.Data?.Remark, Is.EqualTo(response.data.remark));
        });
    }

    [Test]
    public async Task Create_Failed()
    {
        await MockFailedResponse<GroupRequest, CreateGroupResponse>(
            "/api/v1/group/create",
            apiClient => apiClient.Group.CreateAsync,
            new GroupRequest { GroupName = Guid.NewGuid().ToString() }
        );
    }

    [Test]
    public void Create_Canceled()
    {
        TestCancellationToken<GroupRequest, CreateGroupResponse>(
            "/api/v1/group/create",
            apiClient => apiClient.Group.CreateAsync,
            new GroupRequest { GroupName = Guid.NewGuid().ToString() }
        );
    }
}