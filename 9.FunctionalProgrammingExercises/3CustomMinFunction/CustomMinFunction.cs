using System;
using System.Linq;

namespace _3CustomMinFunction
{
    class CustomMinFunction
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            Console.WriteLine(Min(numbers));

        }

        public static Func<int[], int> Min = n =>
        {
            int minNumber = Int32.MaxValue;

            foreach (var number in n)
            {
                if (number < minNumber)
                {
                    minNumber = number;
                }
            }
            return minNumber;
        };
    }
}
