using System;
using System.Collections.Generic;
using System.Linq;

namespace _1ReverseNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<int> numbers = new Stack<int>(input.Split(' ').Select(int.Parse));

            foreach (var numb in numbers)
            {
                Console.Write(numb + " ");
            }
        }
    }
}
