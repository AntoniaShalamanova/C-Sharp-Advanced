using System;
using System.Collections.Generic;
using System.Linq;

namespace _2Sneaking
{
    class Sneaking
    {
        static int playerRow = 0;
        static int playerCol = 0;
        static char[][] room;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            room = new char[rows][];

            FillRoom();

            Queue<char> directions = new Queue<char>();
            char[] symbols = Console.ReadLine().ToCharArray();
            foreach (var symbol in symbols)
            {
                directions.Enqueue(symbol);
            }

            while (directions.Count != 0)
            {
                char currentDirection = directions.Dequeue();

                MovePatrols();

                if (room[playerRow].Contains('d') && Array.IndexOf(room[playerRow], 'd') > playerCol)
                {
                    Console.WriteLine($"Sam died at {playerRow}, {playerCol}");
                    room[playerRow][playerCol] = 'X';
                    break;
                }
                else if (room[playerRow].Contains('b') && Array.IndexOf(room[playerRow], 'b') < playerCol)
                {
                    Console.WriteLine($"Sam died at {playerRow}, {playerCol}");
                    room[playerRow][playerCol] = 'X';
                    break;
                }

                switch (currentDirection)
                {
                    case 'U':
                        MoveSam(-1, 0);
                        break;
                    case 'D':
                        MoveSam(1, 0);
                        break;
                    case 'L':
                        MoveSam(0, -1);
                        break;
                    case 'R':
                        MoveSam(0, 1);
                        break;
                    default:
                        break;
                }

                if (room[playerRow].Contains('N'))
                {
                    int indxOfNikoladze = Array.IndexOf(room[playerRow], 'N');
                    room[playerRow][indxOfNikoladze] = 'X';
                    Console.WriteLine("Nikoladze killed!");
                    break;
                }
            }

            PrintRoom();
        }

        private static void PrintRoom()
        {
            foreach (var row in room)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static void MoveSam(int row, int col)
        {
            room[playerRow][playerCol] = '.';

            playerRow += row;
            playerCol += col;

            room[playerRow][playerCol] = 'S';
        }

        private static void MovePatrols()
        {
            foreach (var row in room)
            {
                int indxD = Array.IndexOf(row, 'd');
                int indxB = Array.IndexOf(row, 'b');

                if (indxD != -1)
                {
                    if (indxD == 0)
                    {
                        row[indxD] = 'b';
                    }
                    else
                    {
                        row[indxD] = '.';
                        row[indxD - 1] = 'd';
                    }
                }
                else if (indxB != -1)
                {
                    if (indxB == row.Length - 1)
                    {
                        row[indxB] = 'd';
                    }
                    else
                    {
                        row[indxB] = '.';
                        row[indxB + 1] = 'b';
                    }
                }
            }
        }

        private static void FillRoom()
        {
            for (int row = 0; row < room.Length; row++)
            {
                room[row] = Console.ReadLine().ToCharArray();

                if (room[row].Contains('S'))
                {
                    playerRow = row;
                    playerCol = Array.IndexOf(room[row], 'S');
                }
            }
        }
    }
}
