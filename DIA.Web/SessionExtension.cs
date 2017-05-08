using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIA.Web
{
    public static class SessionExtension
    {
        public static void SetObject(this ISession session,
                        string key, object value)
        {
            string stringValue = JsonConvert.
                                 SerializeObject(value);
            session.SetString(key, stringValue);
        }

        public static T GetObject<T>(this ISession session,
                                     string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);

        }
    }


}
