using System;
using System.Collections.Generic;
using System.Linq;

namespace _11ParkingSystem
{
    class ParkingSystem
    {
        static void Main(string[] args)
        {
            var parking = new Dictionary<int, List<int>>();
            int steps = 0;

            int[] dimentions = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            int rows = dimentions[0];
            int cols = dimentions[1];

            for (int row = 0; row < rows; row++)
            {
                if (!parking.ContainsKey(row))
                {
                    parking[row] = new List<int> { 0 };
                }
            }

            string input = Console.ReadLine();
            while (input != "stop")
            {
                int[] commands = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int entryRow = commands[0];
                int targetRow = commands[1];
                int targetCol = commands[2];

                if (!parking[targetRow].Contains(targetCol))
                {
                    steps = Math.Abs(targetRow - entryRow) + targetCol + 1;

                    parking[targetRow].Add(targetCol);

                    Console.WriteLine(steps);
                }
                else if (parking[targetRow].Count == cols)
                {
                    Console.WriteLine($"Row {targetRow} full");
                }
                else
                {
                    int counter = 1;

                    while (true)
                    {
                        steps = targetCol - counter;

                        if (steps > 0 && !parking[targetRow].Contains(steps))
                        {
                            parking[targetRow].Add(steps);

                            steps += 1 + Math.Abs(targetRow - entryRow);

                            Console.WriteLine(steps);
                            break;
                        }

                        steps = targetCol + counter;

                        if (steps < cols && !parking[targetRow].Contains(steps))
                        {
                            parking[targetRow].Add(steps);

                            steps += 1 + Math.Abs(targetRow - entryRow);

                            Console.WriteLine(steps);
                            break;
                        }

                        counter++;
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}
