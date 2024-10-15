using AdsPower.LocalApi.Profile;
using AdsPower.LocalApi.Profile.Models;
using AdsPower.LocalApi.Profile.Requests;
using AdsPower.LocalApi.Profile.Responses;
using AdsPower.LocalApi.Shared;
using AdsPower.LocalApi.Tests.Internal;

namespace AdsPower.LocalApi.Tests.Profile;

[TestFixture]
[TestOf(typeof(ProfileApi))]
[Parallelizable(ParallelScope.All)]
[MockTest]
public class ProfileApiMockTests : ApiTestBase
{
    private static readonly CreateProfileRequest CreateProfileRequest = new()
    {
        GroupId = "group-id",
        FingerprintConfig = new FingerprintConfig()
    };

    private static readonly UpdateProfileRequest UpdateProfileRequest = new()
    {
        UserId = "user-id",
        FingerprintConfig = new FingerprintConfig()
    };

    private static readonly ListProfilesRequest ListProfilesRequest = new();

    private static readonly DeleteProfileRequest DeleteProfileRequest = new() { UserIds = [] };

    private static readonly RegroupProfilesRequest RegroupProfilesRequest = new()
    {
        UserIds = ["user-id"],
        GroupId = "group-id"
    };

    #region CreateAsync

    [Test]
    public async Task Create_Success()
    {
        var responseData = new { id = "profile-id" };

        var resultData = await MockSuccessResponse<CreateProfileRequest, CreateProfileResponse, ProfileId>(
            "/api/v1/user/create",
            apiClient => apiClient.Profile.CreateAsync,
            CreateProfileRequest,
            responseData
        );

        Assert.That(resultData.Id, Is.EqualTo(responseData.id));
    }

    [Test]
    public async Task Create_Failed() => await MockFailedResponse<CreateProfileRequest, CreateProfileResponse>(
        "/api/v1/user/create",
        apiClient => apiClient.Profile.CreateAsync,
        CreateProfileRequest
    );

    [Test]
    public void Create_Canceled() => TestCancellationToken<CreateProfileRequest, CreateProfileResponse>(
        "/api/v1/user/create",
        apiClient => apiClient.Profile.CreateAsync,
        CreateProfileRequest
    );

    #endregion

    #region UpdateAsync

    [Test]
    public async Task Update_Success() => await MockSuccessResponse<UpdateProfileRequest, LocalApiResponse>(
        "/api/v1/user/update",
        apiClient => apiClient.Profile.UpdateAsync,
        UpdateProfileRequest
    );

    [Test]
    public async Task Update_Failed() => await MockFailedResponse<UpdateProfileRequest, LocalApiResponse>(
        "/api/v1/user/update",
        apiClient => apiClient.Profile.UpdateAsync,
        UpdateProfileRequest
    );

    [Test]
    public void Update_Canceled() => TestCancellationToken<UpdateProfileRequest, LocalApiResponse>(
        "/api/v1/user/update",
        apiClient => apiClient.Profile.UpdateAsync,
        UpdateProfileRequest
    );

    #endregion

    #region ListAsync

    [Test]
    public async Task List_Success()
    {
        var responseData = new
        {
            list = new[]
            {
                new
                {
                    serial_number = "1",
                    user_id = "user-id",
                    name = "name",
                    group_id = "1",
                    group_name = "group-name",
                    domain_name = "domain.com",
                    username = "username",
                    remark = "remark",
                    sys_app_cate_id = "category",
                    created_time = "1612520997",
                    ip = "13.251.172.174",
                    ip_country = "sg",
                    password = "password",
                    last_open_time = "1623333030"
                }
            },
            page = 1,
            page_size = 50
        };

        var resultData =
            await MockSuccessResponse<ListProfilesRequest, ProfilesListResponse, LocalApiList<ProfileData>>(
                "/api/v1/user/list",
                apiClient => apiClient.Profile.ListAsync,
                ListProfilesRequest,
                responseData
            );

        Assert.Multiple(() =>
        {
            Assert.That(resultData.List, Is.Not.Null.Or.Empty);
            Assert.That(resultData.List[0].SerialNumber, Is.EqualTo(responseData.list[0].serial_number));
            Assert.That(resultData.List[0].UserId, Is.EqualTo(responseData.list[0].user_id));
            Assert.That(resultData.List[0].Name, Is.EqualTo(responseData.list[0].name));
            Assert.That(resultData.List[0].GroupId, Is.EqualTo(responseData.list[0].group_id));
            Assert.That(resultData.List[0].GroupName, Is.EqualTo(responseData.list[0].group_name));
            Assert.That(resultData.List[0].DomainName, Is.EqualTo(responseData.list[0].domain_name));
            Assert.That(resultData.List[0].Username, Is.EqualTo(responseData.list[0].username));
            Assert.That(resultData.List[0].Remark, Is.EqualTo(responseData.list[0].remark));
            Assert.That(resultData.List[0].SysAppCateId, Is.EqualTo(responseData.list[0].sys_app_cate_id));
            Assert.That(resultData.List[0].CreatedTime, Is.EqualTo(responseData.list[0].created_time));
            Assert.That(resultData.List[0].Ip, Is.EqualTo(responseData.list[0].ip));
            Assert.That(resultData.List[0].IpCountry, Is.EqualTo(responseData.list[0].ip_country));
            Assert.That(resultData.List[0].Password, Is.EqualTo(responseData.list[0].password));
            Assert.That(resultData.List[0].LastOpenTime, Is.EqualTo(responseData.list[0].last_open_time));
            // Assert.That(resultData.Page, Is.EqualTo(responseData.page));
            // Assert.That(resultData.PageSize, Is.EqualTo(responseData.page_size));
        });
    }

    [Test]
    public async Task List_Failed() => await MockFailedResponse<ListProfilesRequest, ProfilesListResponse>(
        "/api/v1/user/list",
        apiClient => apiClient.Profile.ListAsync,
        ListProfilesRequest
    );

    [Test]
    public void List_Canceled() => TestCancellationToken<ListProfilesRequest, ProfilesListResponse>(
        "/api/v1/user/list",
        apiClient => apiClient.Profile.ListAsync,
        ListProfilesRequest
    );

    #endregion

    #region DeleteAsync

    [Test]
    public async Task Delete_Success() => await MockSuccessResponse<DeleteProfileRequest, LocalApiResponse>(
        "/api/v1/user/delete",
        apiClient => apiClient.Profile.DeleteAsync,
        DeleteProfileRequest
    );

    [Test]
    public async Task Delete_Failed() => await MockFailedResponse<DeleteProfileRequest, LocalApiResponse>(
        "/api/v1/user/delete",
        apiClient => apiClient.Profile.DeleteAsync,
        DeleteProfileRequest
    );

    [Test]
    public void Delete_Canceled() => TestCancellationToken<DeleteProfileRequest, LocalApiResponse>(
        "/api/v1/user/delete",
        apiClient => apiClient.Profile.DeleteAsync,
        DeleteProfileRequest
    );

    #endregion

    #region RegroupAsync

    [Test]
    public async Task Move_Success() => await MockSuccessResponse<RegroupProfilesRequest, LocalApiResponse>(
        "/api/v1/user/regroup",
        apiClient => apiClient.Profile.RegroupAsync,
        RegroupProfilesRequest
    );

    [Test]
    public async Task Move_Failed() => await MockFailedResponse<RegroupProfilesRequest, LocalApiResponse>(
        "/api/v1/user/regroup",
        apiClient => apiClient.Profile.RegroupAsync,
        RegroupProfilesRequest
    );

    [Test]
    public void Move_Canceled() => TestCancellationToken<RegroupProfilesRequest, LocalApiResponse>(
        "/api/v1/user/regroup",
        apiClient => apiClient.Profile.RegroupAsync,
        RegroupProfilesRequest
    );

    #endregion
    
    #region DeleteCacheAsync

    // TODO: Add tests for DeleteCacheAsync

    #endregion
}