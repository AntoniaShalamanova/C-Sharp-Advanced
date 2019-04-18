using System;
using System.Collections.Generic;
using System.Linq;

namespace _4CupsAndBottles
{
    class CupsAndBottles
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new Queue<int>();
            Stack<int> bottles = new Stack<int>();
            int wastedLiters = 0;

            int[] cupsInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            foreach (var cup in cupsInput)
            {
                cups.Enqueue(cup);
            }

            int[] bottlesInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            foreach (var bottle in bottlesInput)
            {
                bottles.Push(bottle);
            }

            int remWater = 0;

            while (true)
            {
                int currentCup = cups.Peek();
                int currentBottle = bottles.Peek() + remWater;

                if (currentBottle >= currentCup)
                {
                    remWater = 0;
                    wastedLiters += currentBottle - currentCup;
                    cups.Dequeue();
                    bottles.Pop();
                }
                else
                {
                    remWater += bottles.Pop();
                }

                if (bottles.Count == 0)
                {
                    Console.WriteLine($"Cups: {string.Join(" ", cups)}");
                    Console.WriteLine($"Wasted litters of water: {wastedLiters}");
                    break;
                }
                if (cups.Count == 0)
                {
                    Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
                    Console.WriteLine($"Wasted litters of water: {wastedLiters}");
                    break;
                }
            }
        }
    }
}
