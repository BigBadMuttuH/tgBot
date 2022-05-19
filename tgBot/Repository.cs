using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


public struct Repository
{
    static Dictionary<string, List<ModellMessage>> db = new();

    public static string filePath = @"D:\_CODING_\CSharp\BigBadMuutuh_bot\tgBot\tgBot\Repository\data.json";

    public static void Append(ModellMessage model)
    {
        var id = model.message_id;
        if (id != null && db.ContainsKey(id))
        {
            db[id].Add(model);
        }
        else if (id != null)
        {
            db.Add(id, new List<ModellMessage>(new ModellMessage[] { model }));
        }
    }

    public static Dictionary<string, List<ModellMessage>> Read()
    {
        return db;
    }

    public static string GetString()
    {
        string data = string.Empty;
        foreach (var item in db)
        {
            data += $"{item.Key} [{String.Join(' ', item.Value)}]\n";
        }
        return data;
    }

    public static int GetMaxKey()
    {
        int max = 0;
        foreach (var item in db)
        {
            if (int.Parse(item.Key) > max) max = int.Parse(item.Key);
        }

        return max;
    }

    public static void Save()
    {
        File.WriteAllText(filePath, Newtonsoft.Json.JsonConvert.SerializeObject(db));
    }

    public static void Load()
    {
        if (File.Exists(filePath))
        {
            string tmp = File.ReadAllText(filePath);
            db = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, List<ModellMessage>>>(tmp);    

        }
    }
}
