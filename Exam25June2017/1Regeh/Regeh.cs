using System;
using System.Text.RegularExpressions;

namespace _1Regeh
{
    class Regeh
    {
        static string input;

        static void Main(string[] args)
        {
            string pattern = @"\[[^ [\]]+<([0-9]+)REGEH([0-9]+)>[^ []+]";
            input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, pattern);

            int indx = 0;

            foreach (Match match in matches)
            {
                indx += int.Parse(match.Groups[1].Value);
                Console.Write(GetSymbol(indx));

                indx += int.Parse(match.Groups[2].Value);
                Console.Write(GetSymbol(indx));
            }
        }

        private static char GetSymbol(int indx)
        {
            if (indx >= input.Length)
            {
                indx -= input.Length - 1;
            }

            return input[indx];
        }
    }
}
