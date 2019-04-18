using System;
using System.Collections.Generic;

namespace _6TrafficLight
{
    class TrafficLight
    {
        static void Main(string[] args)
        {
            int passNumb = int.Parse(Console.ReadLine());
            int passCarsCount = 0;
            Queue<string> currentCars = new Queue<string>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                switch (input)
                {
                    case "green":
                        for (int i = 0; i < passNumb; i++)
                        {
                            if (currentCars.Count != 0)
                            {
                                Console.WriteLine($"{currentCars.Dequeue()} passed!");
                                passCarsCount++;
                            }
                        }
                        break;

                    default:
                        currentCars.Enqueue(input);
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{passCarsCount} cars passed the crossroads.");
        }
    }
}
