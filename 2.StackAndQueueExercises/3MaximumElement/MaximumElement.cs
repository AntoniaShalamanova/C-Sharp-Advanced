using System;
using System.Collections.Generic;
using System.Linq;

namespace _3MaximumElement
{
    class MaximumElement
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < count; i++)
            {
                string[] query = Console.ReadLine().Split(' ');
                string querieType = query[0];

                switch (querieType)
                {
                    case "1":
                        stack.Push(int.Parse(query[1]));
                        break;

                    case "2":
                        stack.Pop();
                        break;

                    case "3":
                        Console.WriteLine(stack.Max());
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
