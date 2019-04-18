using System;
using System.Linq;

namespace _1MatrixOfPalindromes
{
    class MatrixOfPalindromes
    {
        static void Main(string[] args)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";

            int[] matrixSizes = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            string[,] palindromes = new string[matrixSizes[0], matrixSizes[1]];

            for (int row = 0; row < palindromes.GetLength(0); row++)
            {
                for (int col = 0; col < palindromes.GetLength(1); col++)
                {
                    string firstLetter = alphabet[row].ToString();
                    string secondLetter = alphabet[col + row].ToString();
                    string thirdLetter = alphabet[row].ToString();

                    palindromes[row, col] = firstLetter + secondLetter + thirdLetter;
                }
            }

            for (int row = 0; row < palindromes.GetLength(0); row++)
            {
                for (int col = 0; col < palindromes.GetLength(1); col++)
                {
                    Console.Write(palindromes[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
