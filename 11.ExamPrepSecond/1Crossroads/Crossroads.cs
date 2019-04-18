using System;
using System.Collections.Generic;

namespace _1Crossroads
{
    class Crossroads
    {
        static void Main(string[] args)
        {
            Queue<string> cars = new Queue<string>();
            int passedCars = 0;

            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            while (input != "END")
            {
                if (input != "green")
                {
                    cars.Enqueue(input);
                    input = Console.ReadLine();
                    continue;
                }

                int currentGreenLight = greenLight;

                while (cars.Count > 0 && currentGreenLight > 0)
                {
                    string currentCar = cars.Dequeue();
                    string car = currentCar;
                    currentGreenLight -= currentCar.Length;

                    if (currentGreenLight >= 0)
                    {
                        passedCars++;
                        continue;
                    }

                    currentCar = currentCar.Remove(0, currentCar.Length - Math.Abs(currentGreenLight));

                    currentGreenLight += freeWindow;

                    if (currentGreenLight >= 0)
                    {
                        passedCars++;
                        break;
                    }

                    currentCar = currentCar.Remove(0, currentCar.Length - Math.Abs(currentGreenLight));
                    Console.WriteLine("A crash happened!");
                    Console.WriteLine($"{car} was hit at {currentCar[0]}.");
                    return;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCars} total cars passed the crossroads.");
        }
    }
}
