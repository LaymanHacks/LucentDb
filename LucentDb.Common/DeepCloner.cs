using Newtonsoft.Json;

namespace LucentDb.Common
{
    public static class DeepObjectCloner
    {
        public static T Clone<T>(this T source)
        {
            return ReferenceEquals(source, null)
                ? default(T)
                : JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source));
        }
    }
}