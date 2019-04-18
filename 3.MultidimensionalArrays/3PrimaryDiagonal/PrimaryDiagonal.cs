using System;
using System.Linq;

namespace _3PrimaryDiagonal
{
    class PrimaryDiagonal
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixSize, matrixSize];


            for (int row = 0; row < matrixSize; row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int sum = 0;

            for (int currentDiagonalNumb = 0; currentDiagonalNumb < matrixSize; currentDiagonalNumb++)
            {
                sum += matrix[currentDiagonalNumb, currentDiagonalNumb];
            }

            Console.WriteLine(sum);
        }
    }
}
