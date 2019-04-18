using System;
using System.Collections.Generic;
using System.Linq;

namespace _10PoisonousPlants
{
    class PoisonousPlants
    {
        static void Main(string[] args)
        {
            int plantsNumber = int.Parse(Console.ReadLine());

            List<long> plants = new List<long>(Console.ReadLine()
                .Split(' ')
                .Select(long.Parse)
                .ToList()); 

            long days = 0;
            Stack<int> plantsToRemove = new Stack<int>();

            while (true)
            {
                for (int i = 0; i < plants.Count - 1; i++)
                {
                    long currentPlant = plants[i];
                    long nextPlant = plants[i + 1];

                    if (currentPlant < nextPlant)
                    {
                        plantsToRemove.Push(i + 1);
                    }
                }

                if (plantsToRemove.Count != 0)
                {
                    days++;

                    while (plantsToRemove.Count != 0)
                    {
                        plants.RemoveAt(plantsToRemove.Pop());
                    }
                }
                else
                {
                    Console.WriteLine(days);
                    break;
                }
            }
        }
    }
}
