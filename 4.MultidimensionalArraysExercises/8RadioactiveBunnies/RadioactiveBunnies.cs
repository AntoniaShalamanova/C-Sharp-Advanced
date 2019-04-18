using System;
using System.Collections.Generic;
using System.Linq;

namespace _8RadioactiveBunnies
{
    class RadioactiveBunnies
    {
        static int playerRow;
        static int playerCol;
        static char[][] lair;
        static bool isDead = false;
        static bool isOutside = false;

        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            lair = new char[dimensions[0]][];

            ReadLair();

            string commands = Console.ReadLine();

            MovePlayer(commands);
        }

        private static void MovePlayer(string commands)
        {
            for (int commandId = 0; commandId < commands.Length; commandId++)
            {
                char direction = commands[commandId];

                switch (direction)
                {
                    case 'L':
                        Move(0, -1);
                        break;
                    case 'R':
                        Move(0, 1);
                        break;
                    case 'U':
                        Move(-1, 0);
                        break;
                    case 'D':
                        Move(1, 0);
                        break;
                    default:
                        break;
                }

                BunniesSpread();

                if (isDead)
                {
                    PrintLair();
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    break;
                }
                else if (isOutside)
                {
                    PrintLair();
                    Console.WriteLine($"won: {playerRow} {playerCol}");
                    break;
                }
            }
        }

        private static void BunniesSpread()
        {
            Queue<int[]> bunnies = new Queue<int[]>();

            for (int row = 0; row < lair.Length; row++)
            {
                for (int col = 0; col < lair[row].Length; col++)
                {
                    if (lair[row][col] == 'B')
                    {
                        bunnies.Enqueue(new int[] { row, col });
                    }
                }
            }

            while (bunnies.Count > 0)
            {
                int[] currentBunnie = bunnies.Dequeue();
                int bunnyRow = currentBunnie[0];
                int bunnyCol = currentBunnie[1];

                if (IsInside(bunnyRow + 1, bunnyCol))
                {
                    if (IsPlayer(bunnyRow + 1, bunnyCol))
                    {
                        isDead = true;
                    }

                    lair[bunnyRow + 1][bunnyCol] = 'B';
                }
                if (IsInside(bunnyRow - 1, bunnyCol))
                {
                    if (IsPlayer(bunnyRow - 1, bunnyCol))
                    {
                        isDead = true;
                    }

                    lair[bunnyRow - 1][bunnyCol] = 'B';
                }
                if (IsInside(bunnyRow, bunnyCol + 1))
                {
                    if (IsPlayer(bunnyRow, bunnyCol + 1))
                    {
                        isDead = true;
                    }

                    lair[bunnyRow][bunnyCol + 1] = 'B';
                }
                if (IsInside(bunnyRow, bunnyCol - 1))
                {
                    if (IsPlayer(bunnyRow, bunnyCol - 1))
                    {
                        isDead = true;
                    }

                    lair[bunnyRow][bunnyCol - 1] = 'B';
                }
            }
        }

        private static bool IsPlayer(int row, int col)
        {
            return lair[row][col] == 'P';
        }

        private static void Move(int row, int col)
        {
            int targetRow = playerRow + row;
            int targetCol = playerCol + col;

            if (!IsInside(targetRow, targetCol))
            {
                lair[playerRow][playerCol] = '.';
                isOutside = true;
            }
            else if (IsBunny(targetRow, targetCol))
            {
                lair[playerRow][playerCol] = '.';
                playerRow = targetRow;
                playerCol = targetCol;
                isDead = true;
            }
            else
            {
                lair[playerRow][playerCol] = '.';

                playerRow = targetRow;
                playerCol = targetCol;

                lair[playerRow][playerCol] = 'P';
            }
        }

        private static bool IsBunny(int row, int col)
        {
            return lair[row][col] == 'B';
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 &&
                row < lair.Length &&
                col >= 0 &&
                col < lair[row].Length;
        }

        private static void PrintLair()
        {
            foreach (var row in lair)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static void ReadLair()
        {
            for (int row = 0; row < lair.Length; row++)
            {
                string input = Console.ReadLine();
                lair[row] = new char[input.Length];

                for (int col = 0; col < lair[row].Length; col++)
                {
                    lair[row][col] = input[col];

                    if (lair[row][col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
        }
    }
}
