using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoodMarket.Application.Serialization
{
    public static class SSerializer
    {
        public static readonly JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore
        };

        public static string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj, settings);
        }
        public static T Deserialize<T>(string raw)
        {
            return JsonConvert.DeserializeObject<T>(raw);
        }
    }
}
