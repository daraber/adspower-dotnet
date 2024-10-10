using System.Text.Json;
using System.Text.Json.Serialization;

namespace AdsPower.LocalApi.Internal;

// This converter will convert an empty object to null when deserializing, for example: data: {}
internal sealed class EmptyObjectToNullConverter<T> : JsonConverter<T> where T : class
{
    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions? options)
    {
        if (reader.TokenType == JsonTokenType.StartObject)
        {
            // Advance the reader to see if it's an empty object
            reader.Read();
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                return null;
            }
        }

        // Deserialize normally if it's not an empty object
        return JsonSerializer.Deserialize<T>(ref reader, options);
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        // Use default serialization logic for writing
        JsonSerializer.Serialize(writer, value, options);
    }
}