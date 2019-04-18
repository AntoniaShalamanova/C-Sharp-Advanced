using System;
using System.Collections.Generic;
using System.Linq;

namespace _6TargetPractice
{
    class TargetPractice
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            int rows = matrixSizes[0];
            int cols = matrixSizes[1];

            string snake = Console.ReadLine();

            int[] shotParameters = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            int targetRow = shotParameters[0];
            int targetCol = shotParameters[1];
            int radius = shotParameters[2];

            char[][] stairsMatrix = new char[rows][];

            FillStairs(stairsMatrix, cols, snake);

            for (int currentRow = 0; currentRow < stairsMatrix.Length; currentRow++)
            {
                for (int currentCol = 0; currentCol < stairsMatrix[currentRow].Length; currentCol++)
                {
                    if (IsAffected(stairsMatrix, currentRow, currentCol, targetRow, targetCol, radius))
                    {
                        stairsMatrix[currentRow][currentCol] = ' ';
                    }
                }
            }

            Collapse(stairsMatrix);

            PrintMatrix(stairsMatrix);
        }

        private static void PrintMatrix(char[][] stairsMatrix)
        {
            foreach (var row in stairsMatrix)
            {
                Console.WriteLine(row);
            }
        }

        private static void Collapse(char[][] stairsMatrix)
        {
            for (int currentCol = 0; currentCol < stairsMatrix[0].Length; currentCol++)
            {
                Queue<char> symbols = new Queue<char>(stairsMatrix.Length);

                for (int currentRow = stairsMatrix.Length - 1; currentRow >= 0; currentRow--)
                {
                    if (stairsMatrix[currentRow][currentCol] != ' ')
                    {
                        symbols.Enqueue(stairsMatrix[currentRow][currentCol]);
                    }
                }

                while (symbols.Count <= stairsMatrix.Length)
                {
                    symbols.Enqueue(' ');
                }

                for (int currentRow = stairsMatrix.Length - 1; currentRow >= 0; currentRow--)
                {
                        stairsMatrix[currentRow][currentCol] = symbols.Dequeue();
                }
            }
        }

        private static bool IsAffected(char[][] stairsMatrix, int currentRow, int currentCol, int targetRow, int targetCol, int radius)
        {
            bool IsInside = Math.Pow(currentRow - targetRow, 2) + Math.Pow(currentCol - targetCol, 2) <= Math.Pow(radius, 2);

            if (IsInside)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void FillStairs(char[][] stairsMatrix, int cols, string snake)
        {
            int counter = 0;
            bool IsLeft = true;

            for (int currentRow = stairsMatrix.Length - 1; currentRow >= 0; currentRow--)
            {
                stairsMatrix[currentRow] = new char[cols];

                if (IsLeft)
                {
                    for (int currentCol = stairsMatrix[currentRow].Length - 1; currentCol >= 0; currentCol--)
                    {
                        if (counter == snake.Length)
                        {
                            counter = 0;
                        }

                        stairsMatrix[currentRow][currentCol] = snake[counter];
                        counter++;
                    }

                    IsLeft = false;
                }
                else
                {
                    for (int currentCol = 0; currentCol < stairsMatrix[currentRow].Length; currentCol++)
                    {
                        if (counter == snake.Length)
                        {
                            counter = 0;
                        }

                        stairsMatrix[currentRow][currentCol] = snake[counter];
                        counter++;
                    }

                    IsLeft = true;
                }
            }
        }
    }
}
