using System;
using System.Collections.Generic;

namespace _4CitiesByContinentAndCountry
{
    class CitiesByContinentAndCountry
    {
        static void Main(string[] args)
        {
            var continentsInfo = new Dictionary<string, Dictionary<string, List<string>>>();

            int continentsNumber = int.Parse(Console.ReadLine());

            for (int currentContinent = 0; currentContinent < continentsNumber; currentContinent++)
            {
                string[] info =Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string continent = info[0];
                string country = info[1];
                string city = info[2];

                if (!continentsInfo.ContainsKey(continent))
                {
                    continentsInfo[continent] = new Dictionary<string, List<string>>();
                }

                if (!continentsInfo[continent].ContainsKey(country))
                {
                    continentsInfo[continent][country] = new List<string>();
                }

                continentsInfo[continent][country].Add(city);
            }

            foreach (var continent in continentsInfo)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"{country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
