using System;
using System.Linq;

namespace _2DiagonalDifference
{
    class DiagonalDifference
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixSize, matrixSize];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currentRow = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int firstSum = 0;
            int secondSum = 0;

            for (int indx = 0; indx < matrixSize; indx++)
            {

                firstSum += matrix[indx, indx];
                secondSum += matrix[matrixSize - indx - 1, indx];
            }

            Console.WriteLine(Math.Abs(firstSum - secondSum));
        }
    }
}
