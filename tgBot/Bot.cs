using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public struct Bot
{
    static string token;
    static string baseUri;

    static HttpClient hc = new HttpClient();
    //string url = $"https://api.telegram.org/bot{token}/getUpdates";

    //string json = hc.GetStringAsync(url).Result;
    //JsonParse.Init(json);

    public static void Start()
    {

        while (true)
        {
            string url = $"{baseUri}getUpdates";
            JsonParse.Init(hc.GetStringAsync(url).Result);
            List<ModellMessage> msgs = JsonParse.Parse();

            for (int i = 0; i < msgs.Count; i++)
            {
                Console.WriteLine(ModellMessage.ToString(msgs[i]));
                // эхо бот
                //if(!String.IsNullOrEmpty(msgs[i].chat_id)
                //    && !String.IsNullOrEmpty(msgs[i].text))
                if(msgs[i].text == "/coube")
                {
                    SendMessage(msgs[i].chat_id, "https://coub.com/random");
                }
                Thread.Sleep(60);
            }

            Thread.Sleep(5000);
        }
    }

    public static void Init(string publicToken)
    {
        token = publicToken;
        baseUri = $"https://api.telegram.org/bot{token}/";
    }

    
    public static void SendMessage(string chat_id, string text)
    {
        string url = $"{baseUri}sendMessage?chat_id={chat_id}" +
                     $"&text={text}";
        var req = hc.GetStringAsync(url).Result;
    }
}