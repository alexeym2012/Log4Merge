using Newtonsoft.Json;
using System;
using System.Drawing;

namespace Log4Merge.Domain.Models
{
    public class ColorJsonConverter : JsonConverter<Color>
    {
        public override void WriteJson(JsonWriter writer, Color value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ColorTranslator.ToHtml(value));
        }

        public override Color ReadJson(JsonReader reader, Type objectType, Color existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            return ColorTranslator.FromHtml(reader.Value.ToString());
        }
    }
}
