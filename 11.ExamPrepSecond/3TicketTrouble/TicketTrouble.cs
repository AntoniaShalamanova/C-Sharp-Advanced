using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _3TicketTrouble
{
    class TicketTrouble
    {
        static void Main(string[] args)
        {
            List<string> seats = new List<string>();

            string location = Console.ReadLine();
            string suitcaseContents = Console.ReadLine();

            string curlyPattern = @"{[^}]*\[" + location + @"].*?\[([A-Z]{1}[0-9]{1,2})][^{]*}";
            string squarePattern = @"\[[^]]*{" + location + @"}.*?{([A-Z]{1}[0-9]{1,2})}[^[]*]";

            MatchCollection curlyMatches = Regex.Matches(suitcaseContents, curlyPattern);
            MatchCollection squareMatches = Regex.Matches(suitcaseContents, squarePattern);

            AddSeats(seats, squareMatches);
            AddSeats(seats, curlyMatches);

            if (seats.Count == 2)
            {
                Console.WriteLine($"You are traveling to {location} on seats {seats[0]} and {seats[1]}.");
            }
            else
            {
                for (int i = 0; i < seats.Count; i++)
                {
                    for (int j = i + 1; j < seats.Count; j++)
                    {
                        if (seats[i].Substring(1) == seats[j].Substring(1))
                        {
                            Console.WriteLine($"You are traveling to {location} on seats {seats[i]} and {seats[j]}.");
                            return;
                        }
                    }
                }
            }
        }

        private static void AddSeats(List<string> seats, MatchCollection matches)
        {
            foreach (Match match in matches)
            {
                seats.Add(match.Groups[1].ToString());
            }
        }
    }
}