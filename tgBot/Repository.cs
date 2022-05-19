using Newtonsoft.Json;


public struct Repository
{
    //static Dictionary<string, List<ModellMessage>> db = new();
    static Dictionary<int, List<ModellMessage>> db = new();

    public static string filePath = @"D:\_CODING_\CSharp\BigBadMuutuh_bot\tgBot\tgBot\Repository\";

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

    //public static Dictionary<string, List<ModellMessage>> Read()
    public static Dictionary<int, List<ModellMessage>> Read()
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

    public static int GetLastKey()
    {
        int lastKey = -1;
        if (File.Exists($"{filePath}data.json"))
            lastKey = Read().Keys.Last();

        return lastKey;
    }

    public static void Save()
    {
        Console.WriteLine($"save file: data.json");
        File.WriteAllText(@$"{filePath}data.json", JsonConvert.SerializeObject(db));
    }

    public static void Load()
    {
        if (File.Exists($"{filePath}data.json"))
        {
            Console.WriteLine($"load file: data.json");
            string tmp = File.ReadAllText($"{filePath}data.json");
            //db = JsonConvert.DeserializeObject<Dictionary<string, List<ModellMessage>>>(tmp);
            db = JsonConvert.DeserializeObject<Dictionary<int, List<ModellMessage>>>(tmp);
        }
    }
}
