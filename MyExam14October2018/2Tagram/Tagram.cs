using System;
using System.Collections.Generic;
using System.Linq;

namespace _2Tagram
{
    class Tagram
    {
        static void Main(string[] args)
        {
            var players = new Dictionary<string, Dictionary<string, int>>();
            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] tokens = input
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string username = "";

                if (tokens.Length == 1)
                {
                    string[] banTokens = tokens[0].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    username = banTokens[1];
                    if (players.ContainsKey(username))
                    {
                        players.Remove(username);
                    }

                    input = Console.ReadLine();
                    continue;
                }

                username = tokens[0];
                string tag = tokens[1];
                int likes = int.Parse(tokens[2]);

                if (!players.ContainsKey(username))
                {
                    players[username] = new Dictionary<string, int>();
                }

                if (!players[username].ContainsKey(tag))
                {
                    players[username][tag] = 0;
                }

                players[username][tag] += likes;

                input = Console.ReadLine();
            }

            players = players.OrderByDescending(x => x.Value.Values.Sum())
                .ThenBy(x => x.Value.Keys.Count())
                .ToDictionary(x => x.Key, y => y.Value);

            foreach (var user in players)
            {
                Console.WriteLine(user.Key);

                foreach (var tag in user.Value)
                {
                    Console.WriteLine($"- {tag.Key}: {tag.Value}");
                }
            }
        }
    }
}
