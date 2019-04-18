using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _1DataTransfer
{
    class DataTransfer
    {
        static void Main(string[] args)
        {
            string pattern = @"s:([^;]+);r:([^;]+);m--""([A-z ]+)";
            int totalData = 0;
            List<char> currentData = new List<char>();
            int size = int.Parse(Console.ReadLine());
            string input = "";

            for (int i = 0; i < size; i++)
            {
                input += Console.ReadLine();
            }

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match item in matches)
            {
                string sender = item.Groups[1].Value;
                string receiver = item.Groups[2].Value;
                string message = item.Groups[3].Value;

                currentData.AddRange(sender.Where(x => char.IsDigit(x)));
                currentData.AddRange(receiver.Where(x => char.IsDigit(x)));

                totalData += currentData.Select(x => int.Parse(x.ToString())).Sum();

                currentData.Clear();

                string validSender = "";
                string validReceiver = "";

                foreach (var symbol in sender)
                {
                    if (IsValid(symbol))
                    {
                        validSender += symbol;
                    }
                }

                foreach (var symbol in receiver)
                {
                    if (IsValid(symbol))
                    {
                        validReceiver += symbol;
                    }
                }
                //sender = sender.Where(x => char.IsLetter(x) || x==' ').ToString();
                //receiver = receiver.Where(x => char.IsLetter(x) || x==' ').ToString();
                Console.Write($"{validSender} says \"");
                Console.Write($"{message}\" ");
                Console.Write($"to {validReceiver}");
                Console.WriteLine();
            }

            Console.WriteLine($"Total data transferred: {totalData}MB");
        }

        private static bool IsValid(char symbol)
        {
            return char.IsLetter(symbol) || symbol == ' ';
        }
    }
}
