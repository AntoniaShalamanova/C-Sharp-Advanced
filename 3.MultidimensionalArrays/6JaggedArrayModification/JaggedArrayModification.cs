using System;
using System.Linq;

namespace _6JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixRows = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[matrixRows][];

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                jaggedArray[row] = currentRow;
            }

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] commmand = input
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                string commandType = commmand[0];
                int row = int.Parse(commmand[1]);
                int col = int.Parse(commmand[2]);
                int value = int.Parse(commmand[3]);

                bool isValidCoordinates = row >= 0 &&
                                row <= jaggedArray.Length - 1 &&
                                col >= 0 &&
                                col <= jaggedArray[row].Length - 1;

                if (isValidCoordinates)
                {
                    switch (commandType)
                    {
                        case "Add":
                            jaggedArray[row][col] += value;
                            break;
                        case "Subtract":
                            jaggedArray[row][col] -= value;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }

                input = Console.ReadLine();
            }

            foreach (var row in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
