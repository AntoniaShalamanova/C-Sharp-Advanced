using System;
using System.Collections.Generic;
using System.Linq;

namespace _5CalculateSequenceWithQueue
{
    class CalculateSequenceWithQueue
    {
        static void Main(string[] args)
        {
            long firstNumber = long.Parse(Console.ReadLine());

            List<long> results = new List<long>();
            results.Add(firstNumber);

            Queue<long> numbers = new Queue<long>();
            numbers.Enqueue(firstNumber);

            for (int i = 0; i < 17; i++)
            {
                long currentNumber = numbers.Dequeue();

                long a = currentNumber + 1;
                long b = 2 * currentNumber + 1;
                long c = currentNumber + 2;

                results.Add(a);
                results.Add(b);
                results.Add(c);

                numbers.Enqueue(a);
                numbers.Enqueue(b);
                numbers.Enqueue(c);
            }

            Console.WriteLine(string.Join(" ", results.Take(50)));
        }
    }
}
