using System;
using System.Collections.Generic;
using System.Linq;

namespace _2SetsOfElements
{
    class SetsOfElements
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            int firstArraySize = sizes[0];
            int secondArraySize = sizes[1];

            HashSet<int> firstNumbers = new HashSet<int>();
            HashSet<int> secondNumbers = new HashSet<int>();

            for (int i = 0; i < firstArraySize; i++)
            {
                firstNumbers.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < secondArraySize; i++)
            {
                secondNumbers.Add(int.Parse(Console.ReadLine()));
            }

            Console.WriteLine(string.Join(" ", firstNumbers.Intersect(secondNumbers)));
        }
    }
}
