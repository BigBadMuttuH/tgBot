Console.WriteLine($"load token");
string token = File.ReadAllText($"{Repository.filePath}token");

Repository.Load();
Bot.Init(token);

Bot.Start();
