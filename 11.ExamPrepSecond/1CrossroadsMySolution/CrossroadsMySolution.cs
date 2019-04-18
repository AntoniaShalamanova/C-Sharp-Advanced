using System;
using System.Collections.Generic;

namespace _1CrossroadsMySolution
{
    class CrossroadsMySolution
    {
        static Queue<string> cars;
        static int constGreenLight;
        static int constFreeWindow;
        static int passedCars;

        static void Main(string[] args)
        {
            passedCars = 0;
            cars = new Queue<string>();

            constGreenLight = int.Parse(Console.ReadLine());
            constFreeWindow = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            while (input != "END") 
            {
                switch (input)
                {
                    case "green":
                        int greenLight = constGreenLight;
                        int freeWindow = constFreeWindow;

                        while (true)
                        {
                            if (cars.Count == 0)
                            {
                                break;
                            }

                            greenLight -= cars.Peek().Length;

                            if (greenLight <= 0)
                            {
                                break;
                            }
                            cars.Dequeue();
                            passedCars++;
                        }

                        if (cars.Count == 0)
                        {
                            input = Console.ReadLine();
                            continue;
                        }

                        if (greenLight == 0)
                        {
                            cars.Dequeue();
                            passedCars++;
                            input = Console.ReadLine();
                            continue;
                        }

                        if (greenLight < 0)
                        {
                            greenLight += cars.Peek().Length;
                            if (greenLight + freeWindow >= cars.Peek().Length)
                            {
                                cars.Dequeue();
                                passedCars++;
                                input = Console.ReadLine();
                                continue;
                            }

                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{cars.Peek()} was hit at {cars.Peek()[greenLight + freeWindow]}.");
                            return;
                        }
                        break;


                    default:
                        cars.Enqueue(input);
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCars} total cars passed the crossroads.");
        }
    }
}
