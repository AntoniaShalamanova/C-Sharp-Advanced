using System;
using System.Collections.Generic;

namespace _6ParkingLot
{
    class ParkingLot
    {
        static void Main(string[] args)
        {
            HashSet<string> carsNumbers = new HashSet<string>();

            string currentNumber = Console.ReadLine();

            while (currentNumber != "END")
            {
                string[] carInfo = currentNumber
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                string direction = carInfo[0];
                string number = carInfo[1];

                if (direction == "IN")
                {
                    carsNumbers.Add(number);
                }
                else if (direction == "OUT")
                {
                    carsNumbers.Remove(number);
                }

                currentNumber = Console.ReadLine();
            }

            if (carsNumbers.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var number in carsNumbers)
                {
                    Console.WriteLine(number);
                }
            }
        }
    }
}
