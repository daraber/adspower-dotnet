using System.Diagnostics.CodeAnalysis;

namespace AdsPower.LocalApi.Internal;

internal static class ApiExceptionHelper
{
    public static void ThrowIfNotSuccessStatusCode(HttpResponseMessage response, Type responseType)
    {
        if (!response.IsSuccessStatusCode)
        {
            var message = $"Bad HTTP response from {response.RequestMessage?.RequestUri} for type {responseType.Name}: {response.StatusCode} {response.ReasonPhrase}";
            throw new HttpRequestException(message);
        }
    }

    public static void ThrowIfDeserializedResponseIsNull<T>([NotNull] T? result, string path)
    {
        if (result is null)
        {
            var message = $"The deserialized HTTP response from {path} for type {typeof(T).Name} is null.";
            throw new HttpRequestException(message);
        }
    }
}