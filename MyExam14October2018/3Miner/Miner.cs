using System;
using System.Collections.Generic;
using System.Linq;

namespace _3Miner
{
    class Miner
    {
        static char[][] field;
        static int minerRow;
        static int minerCol;

        static void Main(string[] args)
        {
            long size = long.Parse(Console.ReadLine());

            field = new char[size][];

            Queue<string> commands = new Queue<string>();
            string[] tokens = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in tokens)
            {
                commands.Enqueue(item);
            }

            FillField();

            while (commands.Count != 0)
            {
                string currentCommand = commands.Dequeue();

                switch (currentCommand)
                {
                    case "left":
                        MoveMiner(0, -1);
                        break;
                    case "right":
                        MoveMiner(0, 1);
                        break;
                    case "up":
                        MoveMiner(-1, 0);
                        break;
                    case "down":
                        MoveMiner(1, 0);
                        break;
                    default:
                        break;
                }

                if (!ChechField('c'))
                {
                    Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                    return;
                }
                if (!ChechField('e'))
                {
                    Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                    return;
                }
            }

            int coalsLeft = 0;

            foreach (var row in field)
            {
                foreach (var col in row)
                {
                    if (col == 'c')
                    {
                        coalsLeft++;
                    }
                }
            }

            Console.WriteLine($"{coalsLeft} coals left. ({minerRow}, {minerCol})");
        }

        private static bool ChechField(char symbol)
        {
            foreach (var row in field)
            {
                foreach (var col in row)
                {
                    if (col == symbol)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static void MoveMiner(int row, int col)
        {
            if (IsInside(minerRow + row, minerCol + col))
            {
                field[minerRow][minerCol] = '*';
                minerRow += row;
                minerCol += col;
            }
            else
            {
                return;
            }

            if (field[minerRow][minerCol] == 'c')
            {
                field[minerRow][minerCol] = 's';
            }
            if (field[minerRow][minerCol] == 'e')
            {
                field[minerRow][minerCol] = 's';
                return;
            }
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < field.Length && col >= 0 && col < field[row].Length;
        }

        private static void FillField()
        {
            for (int row = 0; row < field.Length; row++)
            {
                List<char> currentRow = Console.ReadLine().ToList();
                currentRow.RemoveAll(x => x == ' ');

                field[row] = new char[currentRow.Count];

                for (int i = 0; i < currentRow.Count; i++)
                {
                    field[row][i] = currentRow[i];
                }

                if (field[row].Contains('s'))
                {
                    minerRow = row;
                    minerCol = Array.IndexOf(field[row], 's');
                }
            }
        }
    }
}
