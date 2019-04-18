using System;
using System.Linq;

namespace _4MaximalSum
{
    class MaximalSum
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            int[][] matrix = new int[matrixSizes[0]][];
            int maxSum = int.MinValue;
            int startRow = 0;
            int startCol = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine()
                     .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                     .Select(int.Parse)
                     .ToArray();
            }

            for (int row = 0; row < matrix.Length - 2; row++)
            {
                for (int col = 0; col < matrix[row].Length - 2; col++)
                {
                    int currentSum = 0;

                    for (int sumRow = row; sumRow <= row + 2; sumRow++)
                    {
                        for (int sumCol = col; sumCol <= col + 2; sumCol++)
                        {
                            currentSum += matrix[sumRow][sumCol];
                        }
                    }

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            Console.WriteLine("Sum = " + maxSum);

            for (int row = startRow; row <= startRow + 2; row++)
            {
                for (int col = startCol; col <= startCol + 2; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
