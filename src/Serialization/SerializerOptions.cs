using System.Text.Json;
using System.Text.Json.Serialization;

namespace WVN.WinForms.Serialization
{
    public static class SerializerOptions
    {
        public static JsonSerializerOptions Default
            => new()
            {
                Converters = { new ColorJsonConverter() },
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                PropertyNameCaseInsensitive = true
            };
    }
}
