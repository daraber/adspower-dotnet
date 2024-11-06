using System.Diagnostics.CodeAnalysis;

namespace AdsPower.LocalApi.Internal;

internal static class Throw
{
    public static void IfNotSuccessStatusCode<T>(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            var message = $"Bad HTTP response from {response.RequestMessage?.RequestUri} for type {typeof(T).Name}: {response.StatusCode} {response.ReasonPhrase}";
            throw new HttpRequestException(message);
        }
    }

    public static void IfDeserializedResponseIsNull<T>([NotNull] T? result, string path)
    {
        if (result is null)
        {
            var message = $"The deserialized HTTP response from {path} for type {typeof(T).Name} is null.";
            throw new HttpRequestException(message);
        }
    }
}