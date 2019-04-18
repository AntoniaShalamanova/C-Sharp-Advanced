using System;
using System.Collections.Generic;
using System.Linq;

namespace _4FindEvensOrOdds
{
    class FindEvensOrOdds
    {
        static void Main(string[] args)
        {
            Predicate<int> check = n => n % 2 == 0;

            List<int> numbers = new List<int>();
            int[] size = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            for (int i = size[0]; i <= size[1]; i++)
            {
                numbers.Add(i);
            }

            string type = Console.ReadLine();

            switch (type)
            {
                case "even":
                    Console.WriteLine(string.Join(" ", numbers.Where(x => check(x))));
                    break;
                case "odd":
                    Console.WriteLine(string.Join(" ", numbers.Where(x => check(x) == false)));
                    break;
                default:
                    break;
            }
        }
    }
}
