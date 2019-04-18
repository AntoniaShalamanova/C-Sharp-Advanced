using System;
using System.Collections.Generic;

namespace _4MatchingBrackets
{
    class MatchingBrackets
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<int> openingBrackets = new Stack<int>();

            for (int symbol = 0; symbol < input.Length; symbol++)
            {
                switch (input[symbol])
                {
                    case '(':
                        openingBrackets.Push(symbol);
                        break;

                    case ')':
                        int openingBracketInd = openingBrackets.Pop();
                        int closingBracketInd = symbol;

                        Console.WriteLine(input.Substring(openingBracketInd, closingBracketInd - openingBracketInd + 1));
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
