using System;
using System.Collections.Generic;

namespace _5CountSymbols
{
    class CountSymbols
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> counter = new SortedDictionary<char, int>();

            string text = Console.ReadLine();

            foreach (var symbol in text)
            {
                if (!counter.ContainsKey(symbol))
                {
                    counter[symbol] = 0;
                }

                counter[symbol]++;
            }

            foreach (var symbol in counter)
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
