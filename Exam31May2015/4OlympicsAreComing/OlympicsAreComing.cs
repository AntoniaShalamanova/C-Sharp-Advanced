using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _4OlympicsAreComing
{
    class OlympicsAreComing
    {
        static void Main(string[] args)
        {
            var countryData = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();

            while (input != "report")
            {
                string[] tokens = input
                    .Split('|');

                string athlete = Trim(tokens[0]);
                string country = Trim(tokens[1]);

                if (!countryData.ContainsKey(country))
                {
                    countryData.Add(country, new Dictionary<string, int>());
                }

                if (!countryData[country].ContainsKey(athlete))
                {
                    countryData[country][athlete] = 0;
                }

                countryData[country][athlete]++;

                input = Console.ReadLine();
            }

            foreach (var country in countryData.OrderByDescending(c=>c.Value.Values.Sum()))
            {
                Console.WriteLine($"{country.Key} ({country.Value.Count()} participants): {country.Value.Values.Sum()} wins");
            }
        }

        private static string Trim(string token)
        {
            string pattern = @"[ ]+";

            token = Regex.Replace(token, pattern, " ");
            token = token.Trim();

            return token;
        }
    }
}
