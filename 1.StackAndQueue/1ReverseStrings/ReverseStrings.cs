using System;
using System.Collections.Generic;

namespace _1ReverseStrings
{
    class ReverseStrings
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> reversedString = new Stack<char>(input);

            foreach (var symbol in reversedString)
            {
                Console.Write(symbol);
            }

            Console.WriteLine();
        }
    }
}
