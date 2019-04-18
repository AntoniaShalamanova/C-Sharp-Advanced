using System;
using System.Collections.Generic;
using System.Linq;

namespace _6TruckTour
{
    class TruckTour
    {
        static void Main(string[] args)
        {
            int pumpsCount = int.Parse(Console.ReadLine());

            Queue<int[]> petrolPumps = new Queue<int[]>();

            for (int i = 0; i < pumpsCount; i++)
            {
                int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                petrolPumps.Enqueue(input);
            }

            int indx = 0;
            int totalFuel = 0;

            while (true)
            {
                totalFuel = 0;

                foreach (var currentPump in petrolPumps)
                {
                    int fuel = currentPump[0];
                    int distance = currentPump[1];

                    totalFuel += fuel - distance;

                    if (totalFuel < 0)
                    {
                        indx++;
                        petrolPumps.Enqueue(petrolPumps.Dequeue());
                        break;
                    }
                }

                if (totalFuel >= 0)
                {
                    break;
                }
            }

            Console.WriteLine(indx);
        }
    }
}
