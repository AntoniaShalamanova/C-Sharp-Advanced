using System;
using System.Collections.Generic;

namespace _3PeriodicTable
{
    class PeriodicTable
    {
        static void Main(string[] args)
        {
            SortedSet<string> elements = new SortedSet<string>();

            int inputNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputNumber; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                foreach (var element in input)
                {
                    elements.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
