using System;
using System.Collections.Generic;

namespace _5HotPotato
{
    class HotPotato
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int passNumb = int.Parse(Console.ReadLine());

            Queue<string> kids = new Queue<string>(input.Split(' '));

            while (kids.Count != 1)
            {
                for (int currentKid = 1; currentKid < passNumb; currentKid++)
                {
                    kids.Enqueue(kids.Dequeue());
                }
                Console.WriteLine($"Removed {kids.Dequeue()}");
            }

            Console.WriteLine($"Last is {kids.Dequeue()}");
        }
    }
}
