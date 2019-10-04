using System.Text.Json;

namespace GoodMarket.Common
{
    public static class SSerializer
    {
        public static readonly JsonSerializerOptions DefaultSerializationOptions =
            new JsonSerializerOptions()
            {
                IgnoreNullValues = true,
                WriteIndented = true
            };


        /// <summary>
        /// Сериализация с базовыми опциями (Для использования в Expressions)
        /// </summary>
        public static string SerializeDefault<T>(T obj) => JsonSerializer.Serialize(obj, DefaultSerializationOptions);
        /// <summary>
        /// Десериализация с базовыми опциями (Для использования в Expressions)
        /// </summary>
        public static T DeserializeDefault<T>(string raw) => JsonSerializer.Deserialize<T>(raw, DefaultSerializationOptions);

        /// <summary>
        /// Сериализация с базовыми или кастомными опциями
        /// </summary>
        public static string Serialize<T>(T obj, JsonSerializerOptions options = null)
        {
            if (options == null)
                options = DefaultSerializationOptions;
            return JsonSerializer.Serialize(obj, options);
        }
        /// <summary>
        /// Десериализация с базовыми или кастомными опциями
        /// </summary>
        public static T Deserialize<T>(string raw, JsonSerializerOptions options = null)
        {
            if (options == null)
                options = DefaultSerializationOptions;
            return JsonSerializer.Deserialize<T>(raw, options);
        }
    }
}
