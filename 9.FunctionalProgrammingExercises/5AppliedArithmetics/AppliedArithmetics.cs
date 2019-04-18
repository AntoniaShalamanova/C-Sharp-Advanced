using System;
using System.Linq;

namespace _5AppliedArithmetics
{
    class AppliedArithmetics
    {
        static void Main(string[] args)
        {
            Action<int[]> print = n => Console.Write(string.Join(" ", n));
            Func<int[], int[]> add = n => n.Select(x => x + 1).ToArray();
            Func<int[], int[]> subtract = n => n.Select(x => x - 1).ToArray();
            Func<int[], int[]> multiply = n => n.Select(x => x * 2).ToArray();

            int[] numbers = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            string command = Console.ReadLine();
            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        add(numbers);
                        break;
                    case "subtract":
                        subtract(numbers);
                        break;
                    case "multiply":
                        multiply(numbers);
                        break;
                    case "print":
                        print(numbers);
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
