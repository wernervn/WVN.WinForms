using Newtonsoft.Json;

namespace WVN.WinForms.Extensions
{
    internal static class JsonExtensions
    {
        internal static string ToJson<T>(this T obj, Formatting formatting = Formatting.None)
       => JsonConvert.SerializeObject(obj, formatting);

        internal static T FromJson<T>(this string json)
            => JsonConvert.DeserializeObject<T>(json);
    }
}
