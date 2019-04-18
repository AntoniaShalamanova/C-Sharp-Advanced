using System;

namespace _8PascalTriangle
{
    class PascalTriangle
    {
        static void Main(string[] args)
        {
            int rowsNumber = int.Parse(Console.ReadLine());

            long[][] triangle = new long[rowsNumber][];

            for (int row = 0; row < triangle.Length; row++)
            {
                triangle[row] = new long[row + 1];
                triangle[row][0] = 1;
                triangle[row][row] = 1;
            }

            for (int row = 0; row < triangle.Length; row++)
            {
                if (triangle[row].Length > 2)
                {
                    for (int col = 1 ; col < triangle[row].Length - 1; col++)
                    {
                        triangle[row][col] = triangle[row - 1][col] + triangle[row - 1][col - 1];
                    }
                }
            }

            foreach (var item in triangle)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}
