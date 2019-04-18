using System;
using System.Linq;

namespace _3SquaresInMatrix2x2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            char[,] matrix = new char[matrixSizes[0], matrixSizes[1]];
            int countEqual = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    char firstSymbol = matrix[row, col];

                    bool isEqual = firstSymbol == matrix[row, col + 1] &&
                        firstSymbol == matrix[row + 1, col] &&
                        firstSymbol == matrix[row + 1, col + 1];

                    if (isEqual)
                    {
                        countEqual++;
                    }
                }
            }

            Console.WriteLine(countEqual);
        }
    }
}
