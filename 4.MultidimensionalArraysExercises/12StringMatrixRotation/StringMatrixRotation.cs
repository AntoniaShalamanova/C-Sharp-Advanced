using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _12StringMatrixRotation
{
    class StringMatrixRotation
    {
        static List<List<char>> matrix;

        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            GetMatrix();

            int degrees = GetDegrees(command);

            if (degrees > 360)
            {
                degrees -= (degrees / 360) * 360;
            }

            switch (degrees)
            {
                case 90:
                    Rotate90();
                    break;
                case 180:
                    Rotate180();
                    break;
                case 270:
                    Rotate270();
                    break;
                default:
                    PrintMatrix();
                    break;
            }
        }

        private static void Rotate270()
        {
            for (int col = matrix[0].Count - 1; col >= 0; col--)
            {
                for (int row = 0; row < matrix.Count; row++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static void Rotate180()
        {
            for (int row = matrix.Count - 1; row >= 0; row--)
            {
                for (int col = matrix[row].Count - 1; col >= 0; col--)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static void Rotate90()
        {
            for (int col = 0; col < matrix[0].Count; col++)
            {
                for (int row = matrix.Count - 1; row >= 0; row--)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static void PrintMatrix()
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static void GetMatrix()
        {
            matrix = new List<List<char>>();
            int maxCount = 0;

            string text = Console.ReadLine();

            while (text != "END")
            {
                List<char> currentRow = new List<char>();

                for (int i = 0; i < text.Length; i++)
                {
                    currentRow.Add(text[i]);
                }

                if (maxCount < currentRow.Count)
                {
                    maxCount = currentRow.Count;
                }

                matrix.Add(currentRow);

                text = Console.ReadLine();
            }

            for (int row = 0; row < matrix.Count; row++)
            {
                for (int col = matrix[row].Count; col < maxCount; col++)
                {
                    matrix[row].Add(' ');
                }
            }
        }

        private static int GetDegrees(string command)
        {
            string pattern = @"[\d]+";

            return int.Parse((Regex.Match(command, pattern)).ToString());
        }
    }
}
