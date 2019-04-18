using System;

namespace _2KnightGame
{
    class KnightGame
    {
        static char[][] board;
        static int removedKnights = 0;

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            board = new char[size][];

            FillBoard();

            while (true)
            {
                int maxAttacked = 0;
                int rowToRemove = 0;
                int colToRemove = 0;

                for (int row = 0; row < board.Length; row++)
                {
                    for (int col = 0; col < board[row].Length; col++)
                    {
                        int attacked = 0;

                        if (board[row][col] == 'K')
                        {
                            //upLeft
                            if (IsInside(row - 2, col - 1) && IsKnight(row - 2, col - 1))
                            {
                                attacked++;
                            }

                            //upRight
                            if (IsInside(row - 2, col + 1) && IsKnight(row - 2, col + 1))
                            {
                                attacked++;
                            }

                            //downLeft
                            if (IsInside(row + 2, col - 1) && IsKnight(row + 2, col - 1))
                            {
                                attacked++;
                            }

                            //downRight
                            if (IsInside(row + 2, col + 1) && IsKnight(row + 2, col + 1))
                            {
                                attacked++;
                            }

                            //leftUp
                            if (IsInside(row - 1, col - 2) && IsKnight(row - 1, col - 2))
                            {
                                attacked++;
                            }

                            //leftDown
                            if (IsInside(row + 1, col - 2) && IsKnight(row + 1, col - 2))
                            {
                                attacked++;
                            }

                            //rightUp
                            if (IsInside(row - 1, col + 2) && IsKnight(row - 1, col + 2))
                            {
                                attacked++;
                            }

                            //rightDown
                            if (IsInside(row + 1, col + 2) && IsKnight(row + 1, col + 2))
                            {
                                attacked++;
                            }

                            if (maxAttacked < attacked)
                            {
                                maxAttacked = attacked;
                                rowToRemove = row;
                                colToRemove = col;
                            }
                        }
                    }
                }

                if (maxAttacked > 0)
                {
                    board[rowToRemove][colToRemove] = 'O';
                    removedKnights++;
                }
                else
                {
                    Console.WriteLine(removedKnights);
                    break;
                }
            }
        }

        private static bool IsKnight(int row, int col)
        {
            return board[row][col] == 'K';
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row <= board.Length - 1 &&
                col >= 0 && col <= board[row].Length - 1;
        }

        private static void FillBoard()
        {
            for (int row = 0; row < board.Length; row++)
            {
                board[row] = Console.ReadLine().ToCharArray();
            }
        }
    }
}
