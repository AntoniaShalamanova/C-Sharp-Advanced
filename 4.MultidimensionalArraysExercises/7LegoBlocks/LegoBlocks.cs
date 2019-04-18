using System;
using System.Collections.Generic;
using System.Linq;

namespace _7LegoBlocks
{
    class LegoBlocks
    {
        static void Main(string[] args)
        {
            int rowsNumber = int.Parse(Console.ReadLine());

            int[][] firstMatrix = new int[rowsNumber][];
            int[][] secondMatrix = new int[rowsNumber][];

            ReadMatrix(firstMatrix);
            ReadMatrix(secondMatrix);

            if (IsMatched(firstMatrix, secondMatrix, rowsNumber))
            {
                ReverseSecondMatrix(secondMatrix);

                PrintNewMatrix(firstMatrix, secondMatrix);
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {GetCellsNUmber(firstMatrix, secondMatrix)}");
            }
        }

        private static void ReadMatrix(int[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }
        }

        private static void PrintNewMatrix(int[][] firstMatrix, int[][] secondMatrix)
        {
            int[][] newMatrix = new int[firstMatrix.Length][];

            for (int row = 0; row < newMatrix.Length; row++)
            {
                List<int> currentRow = firstMatrix[row].ToList();

                foreach (var num in secondMatrix[row])
                {
                    currentRow.Add(num);
                }

                newMatrix[row] = currentRow.ToArray();
            }

            foreach (var row in newMatrix)
            {
                Console.WriteLine($"[{string.Join(", ", row)}]");
            }
        }

        private static void ReverseSecondMatrix(int[][] secondMatrix)
        {
            for (int row = 0; row < secondMatrix.Length; row++)
            {
                secondMatrix[row] = secondMatrix[row].Reverse().ToArray();
            }
        }

        private static int GetCellsNUmber(int[][] firstMatrix, int[][] secondMatrix)
        {
            int sum = 0;

            foreach (var row in firstMatrix)
            {
                sum += row.Length;
            }

            foreach (var row in secondMatrix)
            {
                sum += row.Length;
            }

            return sum;
        }

        private static bool IsMatched(int[][] firstMatrix, int[][] secondMatrix, int rowsNumber)
        {
            int firstNumbersCount = firstMatrix[0].Length + secondMatrix[0].Length;
            int currentNumbersCount = 0;

            for (int row = 1; row < rowsNumber; row++)
            {
                currentNumbersCount = firstMatrix[row].Length + secondMatrix[row].Length;

                if (currentNumbersCount != firstNumbersCount)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
