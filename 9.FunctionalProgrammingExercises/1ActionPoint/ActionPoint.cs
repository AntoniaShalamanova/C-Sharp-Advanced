using System;
using System.Linq;

namespace _1ActionPoint
{
    class ActionPoint
    {
        static void Main(string[] args)
        {
            Action<string[]> print = x => Console.WriteLine(string.Join("\n", x));

            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            print(names);
        }
    }
}
