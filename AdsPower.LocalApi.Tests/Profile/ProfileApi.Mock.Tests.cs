using AdsPower.LocalApi.Browser.Requests;
using AdsPower.LocalApi.Browser.Responses;
using AdsPower.LocalApi.Profile;
using AdsPower.LocalApi.Profile.Models;
using AdsPower.LocalApi.Profile.Requests;
using AdsPower.LocalApi.Profile.Responses;
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
}