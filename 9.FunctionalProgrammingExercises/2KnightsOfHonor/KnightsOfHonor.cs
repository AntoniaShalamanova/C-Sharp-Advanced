using System;

namespace _2KnightsOfHonor
{
    class KnightsOfHonor
    {
        static void Main(string[] args)
        {
            Action<string> print = n => Console.WriteLine("Sir " + n);

            string[] names = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var name in names)
            {
                print(name);
            }
        }
    }
}
