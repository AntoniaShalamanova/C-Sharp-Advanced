using System;

namespace _10TheHeiganDance
{
    class TheHeiganDance
    {
        static int playerRow = 7;
        static int playerCol = 7;

        static int plagueCloud = 3500;
        static int eruption = 6000;

        static int playerLifePoints = 18500;
        static double heiganLifePoints = 3000000;

        static bool isCloud = false;
        static string spell;

        static void Main(string[] args)
        {
            double damageToHeigan = double.Parse(Console.ReadLine());

            while (true)
            {
                if (playerLifePoints > 0)
                {
                    heiganLifePoints -= damageToHeigan;
                }

                if (isCloud)
                {
                    playerLifePoints -= plagueCloud;
                    isCloud = false;
                }

                if (playerLifePoints <= 0 || heiganLifePoints <= 0)
                {
                    break;
                }

                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                spell = input[0];
                int targetRow = int.Parse(input[1]);
                int targetCol = int.Parse(input[2]);

                if (!IsInAffectedArea(playerRow, playerCol, targetRow, targetCol))
                {
                    continue;
                }

                bool CanMoveUp = !IsInAffectedArea(playerRow - 1, playerCol, targetRow, targetCol) &&
                   IsInside(playerRow - 1);

                bool CanMoveRight = !IsInAffectedArea(playerRow, playerCol + 1, targetRow, targetCol) &&
                                   IsInside(playerCol + 1);
                bool CanMoveDown = !IsInAffectedArea(playerRow + 1, playerCol, targetRow, targetCol) &&
                                   IsInside(playerRow + 1);
                bool CanMoveLeft = !IsInAffectedArea(playerRow, playerCol - 1, targetRow, targetCol) &&
                                   IsInside(playerCol - 1);

                if (CanMoveUp)
                {
                    playerRow--;
                    continue;
                }
                else if (CanMoveRight)
                {
                    playerCol++;
                    continue;
                }
                else if (CanMoveDown)
                {
                    playerRow++;
                    continue;
                }
                else if (CanMoveLeft)  
                {
                    playerCol--;
                    continue;
                }

                if (spell == "Cloud")
                {
                    playerLifePoints -= plagueCloud;
                    isCloud = true;
                    spell = "Plague Cloud";
                }
                else if (spell == "Eruption")
                {
                    playerLifePoints -= eruption;
                    spell = "Eruption";
                }
            }

            if (heiganLifePoints <= 0)
            {
                Console.WriteLine("Heigan: Defeated!");
            }
            else
            {
                Console.WriteLine($"Heigan: {heiganLifePoints:F2}");
            }

            if (playerLifePoints <= 0)
            {
                Console.WriteLine($"Player: Killed by {spell}");
            }
            else
            {
                Console.WriteLine($"Player: {playerLifePoints}");
            }

            Console.WriteLine($"Final position: {playerRow}, {playerCol}");
        }

        private static bool IsInside(int rcIndx)
        {
            return rcIndx >= 0 && rcIndx < 15;
        }

        private static bool IsInAffectedArea(int playerRow, int playerCol, int targetRow, int targetCol)
        {
            return playerRow >= targetRow - 1 &&
                playerRow <= targetRow + 1 &&
                playerCol >= targetCol - 1 &&
                playerCol <= targetCol + 1;
        }
    }
}
