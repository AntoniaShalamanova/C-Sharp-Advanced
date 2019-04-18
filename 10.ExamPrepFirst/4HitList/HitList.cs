using System;
using System.Collections.Generic;
using System.Linq;

namespace _4HitList
{
    class HitList
    {
        static void Main(string[] args)
        {
            var peopleInfo = new Dictionary<string, Dictionary<string, string>>();
            int targetInfoIndx = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            while (input != "end transmissions")
            {
                string[] tokens = input
                    .Split("=", StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];

                string[] kvps = tokens[1]
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                if (!peopleInfo.ContainsKey(name))
                {
                    peopleInfo[name] = new Dictionary<string, string>();
                }

                foreach (var kvp in kvps)
                {
                    string[] info = kvp.Split(":", StringSplitOptions.RemoveEmptyEntries);
                    string key = info[0];
                    string value = info[1];

                    peopleInfo[name][key] = value;
                }

                input = Console.ReadLine();
            }

            string nameToKill = string.Join("", Console.ReadLine().Skip(5));
            int infoIndx = 0;

            Console.WriteLine($"Info on {nameToKill}:");
            foreach (var kvp in peopleInfo[nameToKill].OrderBy(x => x.Key))
            {
                infoIndx += kvp.Key.Length;
                infoIndx += kvp.Value.Length;
                Console.WriteLine($"---{kvp.Key}: {kvp.Value}");
            }

            Console.WriteLine($"Info index: {infoIndx}");

            if (infoIndx >= targetInfoIndx)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {targetInfoIndx - infoIndx} more info.");
            }
        }
    }
}
