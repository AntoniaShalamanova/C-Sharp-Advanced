using System;
using System.Collections.Generic;

namespace _3DecimalToBinaryConverter
{
    class DecimalToBinaryConverter
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            switch(number)
            {
                case 0:
                Console.WriteLine(0);
                    break;

                default:
                Stack<int> result = new Stack<int>();

                while (number != 0)
                {
                    result.Push(number % 2);
                    number /= 2;
                }

                foreach (var numb in result)
                {
                    Console.Write(numb);
                }
                break;
            }
        }
    }
}
