using Newtonsoft.Json;

namespace CoreSessions_0.ExtensionMethods
{
    public static class SessionExtension
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            string serializedObject = JsonConvert.SerializeObject(value);
            session.SetString(key, serializedObject);
        }

        public static T GetObject<T>(this ISession session, string key) where T : class
        {
            string serializedObject = session.GetString(key);
            if (string.IsNullOrEmpty(serializedObject))
            {
                return null;
            }
            T deserializedObject = JsonConvert.DeserializeObject<T>(serializedObject);
            return deserializedObject;
        }
    }
}
