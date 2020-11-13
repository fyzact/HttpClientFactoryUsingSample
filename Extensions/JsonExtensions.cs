using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HttpClientFactoryUsingSample.Extensions
{
    public static class JsonExtensions
    {
        public static T Deserialize<T>(this string json)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true,
                
            };
            return JsonSerializer.Deserialize<T>(json, options);
        }
    }
}
