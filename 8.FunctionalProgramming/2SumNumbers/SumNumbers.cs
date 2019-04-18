using System;
using System.Linq;

namespace _2SumNumbers
{
    class SumNumbers
    {
        static void Main(string[] args)
        {
            Func<string, int> parse = n => int.Parse(n);

            int[] numbers = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(parse)
                    .ToArray();

            Console.WriteLine(numbers.Length);
            Console.WriteLine(numbers.Sum());
        }
    }
}
