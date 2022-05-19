using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

string filePath = @"D:\_CODING_\CSharp\BigBadMuutuh_bot\tgBot\tgBot\";

string token = File.ReadAllText($"{filePath}token");

Repository.Load();

Bot.Init(token);
Bot.Start();

//Console.ReadKey();
