using System;
using System.Collections.Generic;
using System.Linq;

namespace _7TheVLogger
{
    class TheVLogger
    {
        static void Main(string[] args)
        {
            var website = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                string[] inputInfo = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = inputInfo[1];

                if (command == "joined")
                {
                    string vloggerName = inputInfo[0];

                    if (!website.ContainsKey(vloggerName))
                    {
                        website[vloggerName] = new Dictionary<string, HashSet<string>>();
                        website[vloggerName]["followers"] = new HashSet<string>();
                        website[vloggerName]["following"] = new HashSet<string>();
                    }
                }
                else if (command == "followed")
                {
                    string vloggerName = inputInfo[0];
                    string followingVlogger = inputInfo[2];

                    bool isValid = website.ContainsKey(vloggerName) &&
                        website.ContainsKey(followingVlogger) &&
                        vloggerName != followingVlogger;

                    if (isValid)
                    {
                        website[vloggerName]["following"].Add(followingVlogger);
                        website[followingVlogger]["followers"].Add(vloggerName);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {website.Count} vloggers in its logs.");

            var sortedWebsite = website
                .OrderByDescending(x => x.Value["followers"].Count)
                .ThenBy(x => x.Value["following"].Count);

            int counter = 1;

            foreach (var vlogger in sortedWebsite)
            {
                int followersCount = vlogger.Value["followers"].Count;
                int followingCount = vlogger.Value["following"].Count;

                Console.WriteLine($"{counter}. {vlogger.Key} : {followersCount} followers, {followingCount} following");

                if (counter == 1)
                {
                    foreach (var follower in vlogger.Value["followers"].OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

                counter++;
            }
        }
    }
}
