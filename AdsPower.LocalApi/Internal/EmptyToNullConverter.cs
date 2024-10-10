using System.Text.Json;
using System.Text.Json.Serialization;

namespace AdsPower.LocalApi.Internal;

// This converter will convert an empty object to null when deserializing, for example: data: {}
internal sealed class EmptyObjectToNullConverter<T> : JsonConverter<T> where T : class
{
    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions? options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
        }
        
        var initialState = reader;
        
        if (reader.TokenType == JsonTokenType.StartObject)
        {
            // Read the next token to check if the object is empty
            reader.Read();
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                return null;
            }
            
            reader = initialState;
            return JsonSerializer.Deserialize<T>(ref reader, options);
        }

        // If we encounter an unexpected token type, throw an exception
        throw new JsonException($"Unexpected token type {reader.TokenType} when deserializing {typeToConvert}.");
    }

    
    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        // Use default serialization logic for writing
        JsonSerializer.Serialize(writer, value, options);
    }
}