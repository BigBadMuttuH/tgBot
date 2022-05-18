using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

string token = File.ReadAllText(@"D:\_CODING_\CSharp\BigBadMuutuh_bot\tgBot\tgBot\token");

Bot.Init(token);
Bot.Start();

//Bot.SendMessage("-1001645539995", "Тут какое-то сообщение от бота");
