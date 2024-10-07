using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Surgeon__Day_Hospital_.Helpers
{
    public static class SessionHelper
    {
        // Method to set an object in session as JSON
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        // Method to get an object from session stored as JSON
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
