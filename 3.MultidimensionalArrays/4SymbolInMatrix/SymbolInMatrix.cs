using System;

namespace _4SymbolInMatrix
{
    class SymbolInMatrix
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            char[,] matrix = new char[matrixSize, matrixSize];

            for (int row = 0; row < matrixSize; row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            char searchedSymbol = char.Parse(Console.ReadLine());

            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    if (matrix[row, col] == searchedSymbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{searchedSymbol} does not occur in the matrix");
        }
    }
}
