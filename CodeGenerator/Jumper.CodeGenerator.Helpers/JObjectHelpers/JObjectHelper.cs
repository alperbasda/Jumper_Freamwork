using Newtonsoft.Json.Linq;

namespace Jumper.CodeGenerator.Helpers.JObjectHelpers;

public static class JObjectHelper
{
    public static JObject ToJObject(this string jsonData)
    {
        return JObject.Parse(jsonData);
    }

    public static JToken Get(this JObject obj, string key)
    {
        var val = obj[key];
        if (val == null)
        {
            throw new Exception($"Veri içerisinde {key} değeri bulunamadı. {obj}");
        }
        return obj[key]!;
    }
}
