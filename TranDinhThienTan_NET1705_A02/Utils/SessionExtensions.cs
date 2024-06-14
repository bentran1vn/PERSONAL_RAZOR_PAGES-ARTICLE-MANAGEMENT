using BusinessObjects;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace TranDinhThienTan_NET1705_A02.Utils;

public static class SessionExtensions
{
    public static void SetObjectAsJson(this ISession session, string key, object value)
    {
        session.SetString(key, JsonConvert.SerializeObject(value));
    }

    public static T? GetObjectFromJson<T>(this ISession session, string key)
    {
        var value = session.GetString(key);
        return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
    }
    
    public static void SetList<T>(this ISession session, string key, List<T> list) where T : class
    {
        var jsonString = JsonSerializer.Serialize(list);
        session.SetString(key, jsonString);
    }
    
    public static List<T>? GetList<T>(this ISession session, string key) where T : class
    {
        var listJson = session.GetString(key);
        return listJson == null ? null : JsonSerializer.Deserialize<List<T>>(listJson);
    }

    public static void WriteHistory(this ISession session, string entity, string action)
    {
        var listJson = session.GetString("History");
        if (listJson != null)
        {
            List<History> list =  JsonSerializer.Deserialize<List<History>>(listJson);
            list.Add(new History()
            {
                Enitity = entity,
                Action = action,
                CreateAt = DateTime.Now
            });
            session.SetList("History",list);
        }
    }
}