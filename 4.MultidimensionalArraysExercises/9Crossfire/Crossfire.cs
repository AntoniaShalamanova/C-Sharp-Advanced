using System;
using System.Collections.Generic;
using System.Linq;

namespace _9Crossfire
{
    class Crossfire
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            int rows = dimentions[0];
            int cols = dimentions[1];

            List<List<int>> matrix = new List<List<int>>();

            FillMatrix(matrix, rows, cols);

            string input = Console.ReadLine();

            while (input != "Nuke it from orbit")
            {
                int[] coordinates = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int targetRow = coordinates[0];
                int targetCol = coordinates[1];
                int radius = coordinates[2];

                Attak(matrix, targetRow, targetCol, radius);

                input = Console.ReadLine();
            }

            PrintMatrix(matrix);
        }

        private static void Attak(List<List<int>> matrix, int targetRow, int targetCol, int radius)
        {
            for (int row = targetRow - radius; row <= targetRow + radius; row++)
            {
                if (IsInside(matrix, row, targetCol))
                {
                    matrix[row][targetCol] = 0;
                }
            }

            for (int col = targetCol - radius; col <= targetCol + radius; col++)
            {
                if (IsInside(matrix, targetRow, col))
                {
                    matrix[targetRow][col] = 0;
                }
            }

            for (int row = 0; row < matrix.Count; row++)
            {
                matrix[row].RemoveAll(x => x == 0);

                if (matrix[row].Count == 0)
                {
                    matrix.RemoveAt(row);
                    row--;
                }
            }
        }

        private static bool IsInside(List<List<int>> matrix, int row, int col)
        {
            return row >= 0 && row < matrix.Count && col >= 0 && col < matrix[row].Count;
        }

        private static void PrintMatrix(List<List<int>> matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static void FillMatrix(List<List<int>> matrix, int rows, int cols)
        {
            int counter = 1;

            for (int row = 0; row < rows; row++)
            {
                List<int> currentRow = new List<int>();

                for (int col = 0; col < cols; col++)
                {
                    currentRow.Add(counter);
                    counter++;
                }

                matrix.Add(currentRow);
            }
        }
    }
}
