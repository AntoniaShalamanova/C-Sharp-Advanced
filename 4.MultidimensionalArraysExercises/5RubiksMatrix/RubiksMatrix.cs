using System;
using System.Linq;

namespace _5RubiksMatrix
{
    class RubiksMatrix
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = Console.ReadLine()
                     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                     .Select(int.Parse)
                     .ToArray();

            int commandsCount = int.Parse(Console.ReadLine());

            int matrixRows = matrixSizes[0];
            int matrixCols = matrixSizes[1];

            int[][] rubikMatrix = new int[matrixRows][];

            MakeMatrix(rubikMatrix, matrixCols);

            for (int currentCommand = 0; currentCommand < commandsCount; currentCommand++)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int rowColIndx = int.Parse(command[0]);
                string direction = command[1];
                int steps = int.Parse(command[2]);

                switch (direction)
                {
                    case "up":
                        MoveUp(rowColIndx, direction, steps, rubikMatrix);
                        break;

                    case "down":
                        MoveDown(rowColIndx, direction, steps, rubikMatrix);
                        break;

                    case "left":
                        MoveLeft(rowColIndx, direction, steps, rubikMatrix);
                        break;

                    case "right":
                        MoveRight(rowColIndx, direction, steps, rubikMatrix);
                        break;

                    default:
                        break;
                }
            }

            RearrangeMatrix(rubikMatrix);
        }

        private static void RearrangeMatrix(int[][] rubikMatrix)
        {
            int searchedNumber = 1;

            for (int currentRow = 0; currentRow < rubikMatrix.Length; currentRow++)
            {
                for (int currentCol = 0; currentCol < rubikMatrix[currentRow].Length; currentCol++)
                {
                    if (rubikMatrix[currentRow][currentCol] == searchedNumber)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        for (int searchedRow = currentRow; searchedRow < rubikMatrix.Length; searchedRow++)
                        {
                            for (int searchedCol = 0; searchedCol < rubikMatrix[searchedRow].Length; searchedCol++)
                            {
                                if (rubikMatrix[searchedRow][searchedCol] == searchedNumber)
                                {
                                    Console.WriteLine($"Swap ({currentRow}, {currentCol}) with ({searchedRow}, {searchedCol})");

                                    int swap = rubikMatrix[currentRow][currentCol];
                                    rubikMatrix[currentRow][currentCol] = rubikMatrix[searchedRow][searchedCol];
                                    rubikMatrix[searchedRow][searchedCol] = swap;
                                    break;
                                }
                            }
                        }
                    }

                    searchedNumber++;
                }
            }
        }

        private static void MoveRight(int row, string direction, int steps, int[][] rubikMatrix)
        {
            steps %= rubikMatrix[row].Length;

            for (int currentStep = 1; currentStep <= steps; currentStep++)
            {
                int lastElement = rubikMatrix[row][rubikMatrix[row].Length - 1];

                for (int col = rubikMatrix[row].Length - 1; col > 0; col--)
                {
                    rubikMatrix[row][col] = rubikMatrix[row][col - 1];
                }

                rubikMatrix[row][0] = lastElement;
            }
        }

        private static void MoveLeft(int row, string direction, int steps, int[][] rubikMatrix)
        {
            steps %= rubikMatrix[row].Length;

            for (int currentStep = 1; currentStep <= steps; currentStep++)
            {
                int firstElement = rubikMatrix[row][0];

                for (int col = 0; col < rubikMatrix[row].Length - 1; col++)
                {
                    rubikMatrix[row][col] = rubikMatrix[row][col + 1];
                }

                rubikMatrix[row][rubikMatrix[row].Length - 1] = firstElement;
            }
        }

        private static void MoveDown(int col, string direction, int steps, int[][] rubikMatrix)
        {
            steps %= rubikMatrix.Length;

            for (int currentStep = 1; currentStep <= steps; currentStep++)
            {
                int lastNumber = rubikMatrix[rubikMatrix.Length - 1][col];

                for (int row = rubikMatrix.Length - 1; row > 0; row--)
                {
                    rubikMatrix[row][col] = rubikMatrix[row - 1][col];
                }

                rubikMatrix[0][col] = lastNumber;
            }
        }

        private static void MoveUp(int col, string direction, int steps, int[][] rubikMatrix)
        {
            steps %= rubikMatrix.Length;

            for (int currentStep = 1; currentStep <= steps; currentStep++)
            {
                int firstNumber = rubikMatrix[0][col];

                for (int row = 0; row < rubikMatrix.Length - 1; row++)
                {
                    rubikMatrix[row][col] = rubikMatrix[row + 1][col];
                }

                rubikMatrix[rubikMatrix.Length - 1][col] = firstNumber;
            }
        }

        private static void PrintMatrix(int[][] rubikMatrix)
        {
            foreach (var row in rubikMatrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static void MakeMatrix(int[][] rubikMatrix, int matrixCols)
        {
            int number = 1;

            for (int row = 0; row < rubikMatrix.Length; row++)
            {
                rubikMatrix[row] = new int[matrixCols];

                for (int col = 0; col < rubikMatrix[row].Length; col++)
                {
                    rubikMatrix[row][col] = number;
                    number++;
                }
            }
        }
    }
}