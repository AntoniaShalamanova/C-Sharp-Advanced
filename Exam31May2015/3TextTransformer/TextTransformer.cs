using System;
using System.Text.RegularExpressions;

namespace _3TextTransformer
{
    class TextTransformer
    {
        static void Main(string[] args)
        {
            string patternWeightOne = @"(\$)[^$%&' ]+?(\$)";
            string patternWeightTwo = @"(\%)[^$%&' ]+?(\%)";
            string patternWeightThree = @"(\&)[^$%&' ]+?(\&)";
            string patternWeightFour = @"(\')[^$%&' ]+?(\')";
            string patternWhiteSpace = @"[ ]+";
            string sequence = "";
            int add = 0;

            string input = Console.ReadLine();
            while (input != "burp")
            {
                sequence += input;

                input = Console.ReadLine();
            }

            //string[] sequenceArray = sequence.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            //sequence = string.Join(" ", sequenceArray);
            sequence = Regex.Replace(sequence, patternWhiteSpace, " ");

            if (Regex.Matches(sequence, patternWeightOne).Count > 0)
            {
                add = 1;
                Print(sequence, add, patternWeightOne);
            }
            if (Regex.Matches(sequence, patternWeightTwo).Count > 0)
            {
                add = 2;
                Print(sequence, add, patternWeightTwo);
            }
            if (Regex.Matches(sequence, patternWeightThree).Count > 0)
            {
                add = 3;
                Print(sequence, add, patternWeightThree);
            }
            if (Regex.Matches(sequence, patternWeightFour).Count > 0)
            {
                add = 4;
                Print(sequence, add, patternWeightFour);
            }
        }

        private static void Print(string sequence, int add, string pattern)
        {
            MatchCollection words = Regex.Matches(sequence, pattern);

            foreach (var word in words)
            {
                for (int i = 1; i < word.ToString().Length - 1; i++)
                {
                    if (i % 2 == 0)
                    {
                        Console.Write((char)(word.ToString()[i] - add));
                    }
                    else
                    {
                        Console.Write((char)(word.ToString()[i] + add));
                    }
                }
                Console.Write(" ");
            }
        }
    }
}
