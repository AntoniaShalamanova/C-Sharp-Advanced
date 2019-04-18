using System;
using System.Collections.Generic;

namespace _8StackFibonacci
{
    class StackFibonacci
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());

            long[] beginingNumbers = { 0, 1 };

            Stack<long> fibonacciNumbers = new Stack<long>(beginingNumbers);

            for (int i = 0; i < number - 1; i++)
            {
                long lastNumber = fibonacciNumbers.Pop();
                long beforeLastNumber = fibonacciNumbers.Peek();

                fibonacciNumbers.Push(lastNumber);
                fibonacciNumbers.Push(lastNumber + beforeLastNumber);
            }

            Console.WriteLine(fibonacciNumbers.Peek());
        }
    }
}
