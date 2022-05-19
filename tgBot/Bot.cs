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

    public static void BotThread()
    {
        while (true)
        {
            string url = $"{baseUri}getUpdates";
            JsonParse.Init(hc.GetStringAsync(url).Result);
            List<ModellMessage> msgs = JsonParse.Parse();

            Repository.Load();

            foreach (ModellMessage msg in msgs)
            {
                int max = Repository.GetMaxKey();
                if (int.Parse(msg.message_id) > max
                    &&
                    msg.text == "/coube")
                {
                    SendMessage(msg.chat_id, "https://coub.com/random");
                }

                if (msg.message_id != null
                    && !Repository.Read().ContainsKey(msg.message_id))
                {
                    Repository.Append(msg);
                }

                Thread.Sleep(600);
            }
            Console.WriteLine(Repository.GetString());
            //break;

            Thread.Sleep(6000);
            Repository.Save();
            Console.Clear();
        }

    }

    public static void Start()
    {
        Thread t = new Thread(new ThreadStart(BotThread));
        t.Start();
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