using System.Text.Encodings.Web;
using System.Text.Json;

namespace AITest.Util
{
    public class Tools
    {
        private static JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true // 可选：美化输出，带缩进
        };

        public static string ToJson<T>(T obj) {
            return JsonSerializer.Serialize(obj, options);
        }

        public static string CleanString(string input)
        {
            return input.Trim();
        }
    }
}