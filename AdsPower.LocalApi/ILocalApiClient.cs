using AdsPower.LocalApi.Shared;

namespace AdsPower.LocalApi;

public interface ILocalApiClient
{
    /// <summary>
    /// Checks the availability of the current device API interface.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    Task<LocalApiResponse> GetConnectionStatusAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends a GET request to the specified path with optional query parameters and returns the deserialized response.
    /// </summary>
    /// <typeparam name="T">The type of the response object, which must inherit from <see cref="LocalApiResponse"/>.</typeparam>
    /// <param name="path">The relative path of the API endpoint.</param>
    /// <param name="request">An optional object implementing <see cref="IQueryParameterizeable"/> to provide query parameters.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The task object representing the asynchronous operation, containing the deserialized response of type <typeparamref name="T"/>.</returns>
    /// <exception cref="HttpRequestException">Thrown when the HTTP response is unsuccessful or the response content cannot be deserialized.</exception>
    Task<T> GetAsync<T>(string path, IQueryParameterizeable? request, CancellationToken cancellationToken = default)
        where T : LocalApiResponse;

    /// <summary>
    /// Sends a POST request to the specified path with the provided request object and returns the deserialized response.
    /// </summary>
    /// <typeparam name="T">The type of the response object, which must inherit from <see cref="LocalApiResponse"/>.</typeparam>
    /// <param name="path">The relative path of the API endpoint.</param>
    /// <param name="request">The request object to be sent in the body of the POST request.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The task object representing the asynchronous operation, containing the deserialized response of type <typeparamref name="T"/>.</returns>
    /// <exception cref="HttpRequestException">Thrown when the HTTP response is unsuccessful or the response content cannot be deserialized.</exception>
    Task<T> PostAsync<T>(string path, object request, CancellationToken cancellationToken = default)
        where T : LocalApiResponse;
}