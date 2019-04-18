using System;
using System.Collections.Generic;
using System.Linq;

namespace _1KeyRevolver
{
    class KeyRevolver
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>();
            int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            foreach (var bullet in input)
            {
                bullets.Push(bullet);
            }

            Queue<int> locks = new Queue<int>();
            input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            foreach (var currentLock in input)
            {
                locks.Enqueue(currentLock);
            }

            int intelligence = int.Parse(Console.ReadLine());

            int count = gunBarrelSize;
            int usedBullets = 0;
            while (true)
            {
                int bullet = bullets.Pop();
                int currentLock = locks.Peek();
                count--;
                usedBullets++;

                if (bullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (count == 0 && bullets.Count() > 0)
                {
                    Console.WriteLine("Reloading!");
                    count = gunBarrelSize;
                }

                if (locks.Count() == 0)
                {
                    int moneyEarned = intelligence - usedBullets * bulletPrice;
                    Console.WriteLine($"{bullets.Count()} bullets left. Earned ${moneyEarned}");
                    break;
                }
                else if (bullets.Count() == 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count()}");
                    break;
                }
            }
        }
    }
}
