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
        var responseData = new
        {
            group_id = "group-id",
            group_name = "group-name",
            remark = "group-remark"
        };

        var resultData = await MockSuccessResponse<GroupRequest, CreateGroupResponse, LocalApi.Group.Models.Group>(
            "/api/v1/group/create",
            apiClient => apiClient.Group.CreateAsync,
            new GroupRequest { GroupName = Guid.NewGuid().ToString() },
            responseData
        );

        Assert.Multiple(() =>
        {
            Assert.That(resultData.GroupId, Is.EqualTo(responseData.group_id));
            Assert.That(resultData.GroupName, Is.EqualTo(responseData.group_name));
            Assert.That(resultData.Remark, Is.EqualTo(responseData.remark));
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