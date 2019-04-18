using System;
using System.Collections.Generic;
using System.Linq;

namespace _7GroupNumbers
{
    class GroupNumbers
    {
        static void Main(string[] args)
        {
            List<int> numbers =Console.ReadLine()
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

            int[][] groupedNumbers = new int[3][];

            groupedNumbers[0] = numbers.Where(x => Math.Abs(x) % 3 == 0).ToArray();
            groupedNumbers[1] = numbers.Where(x => Math.Abs(x) % 3 == 1).ToArray();
            groupedNumbers[2] = numbers.Where(x => Math.Abs(x) % 3 == 2).ToArray();

            foreach (var row in groupedNumbers)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
