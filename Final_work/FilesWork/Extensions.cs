using Newtonsoft.Json;

namespace Final_work
{
    public static class Extensions
    {
        public static string ToJson(this object obj) => 
            JsonConvert.SerializeObject(obj);

        public static T FromJson<T>(this string json) => 
            JsonConvert.DeserializeObject<T>(json);
    }
}
