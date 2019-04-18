using System;
using System.Collections.Generic;
using System.Linq;

namespace _4BasicQueueOperations
{
    class BasicQueueOperations
    {
        static void Main(string[] args)
        {
            var operations = Console.ReadLine().Split(' ');

            int pushNumb = int.Parse(operations[0]);
            int popNumb = int.Parse(operations[1]);
            int searchNUmb = int.Parse(operations[2]);

            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Queue<int> currentNumbers = new Queue<int>();

            for (int i = 0; i < pushNumb && i < numbers.Length; i++)
            {
                currentNumbers.Enqueue(numbers[i]);
            }


            for (int i = 0; i < popNumb && currentNumbers.Count != 0; i++)
            {
                currentNumbers.Dequeue();
            }

            if (currentNumbers.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (currentNumbers.Contains(searchNUmb))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(currentNumbers.Min());
            }
        }
    }
}
