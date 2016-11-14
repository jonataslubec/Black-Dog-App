using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace BlackDog.Helpers
{
    public static class JsonHelper<T> where T : class, new()
    {
        public static List<T> FromJSON_List(string jsonValue, bool @interface = false)
        {
            if (jsonValue == null)
                return new List<T>();

            if (@interface)
                return JsonConvert.DeserializeObject<List<T>>(jsonValue, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            else
                return JsonConvert.DeserializeObject<List<T>>(jsonValue);
        }

        public static T FromJSON_Object(string jsonValue, bool @interface = false)
        {
            if (jsonValue == null)
                return new T();

            if (@interface)

                return JsonConvert.DeserializeObject<T>(jsonValue, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            else
                return JsonConvert.DeserializeObject<T>(jsonValue);

        }

        public static string ToJSON_List(List<T> t, bool @interface = false)
        {
            if (t == null)
                return string.Empty;

            if (@interface)
                return JsonConvert.SerializeObject(t, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            else
                return JsonConvert.SerializeObject(t);
        }

        public static string ToJSON_Object(T t, bool @interface = false)
        {
            if (t == null)
                return string.Empty;

            if (@interface)
                return JsonConvert.SerializeObject(t, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            else
                return JsonConvert.SerializeObject(t);
        }

        public static string ToJSON_ObjectChart(T t, bool @interface = false)
        {
            if (t == null)
                return string.Empty;

            if (@interface)
            {
                return JsonConvert.SerializeObject(t, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All,
                    TypeNameAssemblyFormat = FormatterAssemblyStyle.Full
                });
            }
            else
                return JsonConvert.SerializeObject(t);
        }


        public static T FromJSON_ObjectChart(string jsonValue, bool @interface = false)
        {
            if (jsonValue == null)
                return new T();

            if (@interface)
            {
                return JsonConvert.DeserializeObject<T>(jsonValue, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects,
                    TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Full
                });
            }
            else
                return JsonConvert.DeserializeObject<T>(jsonValue);
        }
    }
}
