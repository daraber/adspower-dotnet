using AdsPower.LocalApi.Group;
using AdsPower.LocalApi.Group.Requests;
using AdsPower.LocalApi.Group.Responses;
using AdsPower.LocalApi.Shared;
using AdsPower.LocalApi.Tests.Internal;
using GroupModel = AdsPower.LocalApi.Group.Models.Group;

namespace AdsPower.LocalApi.Tests.Group;

[TestFixture]
[TestOf(typeof(GroupApi))]
[Parallelizable(ParallelScope.All)]
[MockTest]
public class GroupApiMockTests : ApiTestBase
{
    #region CreateAsync

    [Test]
    public async Task Create_Success()
    {
        var responseData = new
        {
            group_id = "group-id",
            group_name = "group-name",
            remark = "group-remark"
        };

        var resultData = await MockSuccessResponse<GroupRequest, CreateGroupResponse, GroupModel>(
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
    public async Task Create_Failed() => await MockFailedResponse<GroupRequest, CreateGroupResponse>(
        "/api/v1/group/create",
        apiClient => apiClient.Group.CreateAsync,
        new GroupRequest { GroupName = Guid.NewGuid().ToString() }
    );

    [Test]
    public void Create_Canceled() => TestCancellationToken<GroupRequest, CreateGroupResponse>(
        "/api/v1/group/create",
        apiClient => apiClient.Group.CreateAsync,
        new GroupRequest { GroupName = Guid.NewGuid().ToString() }
    );

    #endregion

    #region UpdateAsync

    [Test]
    public async Task Update_Success() => await MockSuccessResponse<UpdateGroupRequest, LocalApiResponse>(
        "/api/v1/group/update",
        apiClient => apiClient.Group.UpdateAsync,
        new UpdateGroupRequest { GroupName = "group-name-1", GroupId = "group-id-1" }
    );

    [Test]
    public async Task Update_Failed() => await MockFailedResponse<UpdateGroupRequest, LocalApiResponse>(
        "/api/v1/group/update",
        apiClient => apiClient.Group.UpdateAsync,
        new UpdateGroupRequest { GroupName = "group-name-1", GroupId = "group-id-1" }
    );

    [Test]
    public void Update_Canceled() => TestCancellationToken<UpdateGroupRequest, LocalApiResponse>(
        "/api/v1/group/create",
        apiClient => apiClient.Group.UpdateAsync,
        new UpdateGroupRequest { GroupName = "group-name-1", GroupId = "group-id-1" }
    );

    #endregion

    #region ListAsync

    [Test]
    public async Task ListAsync_Success()
    {
        var responseData = new
        {
            list = new[]
            {
                new
                {
                    group_id = "group-id-1",
                    group_name = "group-name-1",
                    remark = "group-remark-1"
                },
                new
                {
                    group_id = "group-id-2",
                    group_name = "group-name-2",
                    remark = "group-remark-2"
                }
            },
            page = 1,
            page_size = 10
        };

        var resultData =
            await MockSuccessResponse<ListGroupsRequest, GroupListResponse, LocalApiList<GroupModel>>(
                "/api/v1/group/list",
                apiClient => apiClient.Group.ListAsync,
                new ListGroupsRequest { GroupName = "group-name-1" },
                responseData
            );

        Assert.Multiple(() =>
        {
            Assert.That(resultData.List, Is.Not.Null.Or.Empty);
            Assert.That(resultData.List, Has.Count.EqualTo(2));
            Assert.That(resultData.List[0].GroupId, Is.EqualTo(responseData.list[0].group_id));
            Assert.That(resultData.List[0].GroupName, Is.EqualTo(responseData.list[0].group_name));
            Assert.That(resultData.List[0].Remark, Is.EqualTo(responseData.list[0].remark));
            Assert.That(resultData.List[1].GroupId, Is.EqualTo(responseData.list[1].group_id));
            Assert.That(resultData.List[1].GroupName, Is.EqualTo(responseData.list[1].group_name));
            Assert.That(resultData.List[1].Remark, Is.EqualTo(responseData.list[1].remark));
        });
    }

    [Test]
    public async Task ListAsync_Failed() => await MockFailedResponse<ListGroupsRequest, GroupListResponse>(
        "/api/v1/group/list",
        apiClient => apiClient.Group.ListAsync,
        new ListGroupsRequest { GroupName = Guid.NewGuid().ToString() }
    );

    [Test]
    public void ListAsync_Canceled() => TestCancellationToken<ListGroupsRequest, GroupListResponse>(
        "/api/v1/group/list",
        apiClient => apiClient.Group.ListAsync,
        new ListGroupsRequest { GroupName = Guid.NewGuid().ToString() }
    );

    #endregion
}