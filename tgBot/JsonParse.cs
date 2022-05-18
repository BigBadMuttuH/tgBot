using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

public struct JsonParse
{
    static string json;

    public static void Init(string jsonString)
    {
        json = jsonString;
    }

    public static List<ModellMessage> Parse()
    {
        List<ModellMessage> messagers = new();
        JObject result = JObject.Parse(json);
        JToken resultData = result["result"]!;

        foreach (JToken msg in resultData)
        {
            ModellMessage mm = new();
            mm.update_id = msg["update_id"]?.ToString();
            mm.chat_id = msg["channel_post"]?["sender_chat"]?["id"]?.ToString();
            mm.message_id = msg["channel_post"]?["message_id"]?.ToString();
            mm.text = msg["channel_post"]?["text"]?.ToString();

            messagers.Add(mm);
        }

        return messagers;
    }
}