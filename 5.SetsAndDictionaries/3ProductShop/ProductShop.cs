using System;
using System.Collections.Generic;

namespace _3ProductShop
{
    class ProductShop
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shopsInfo = new SortedDictionary<string, Dictionary<string, double>>();

            string input = Console.ReadLine();

            while (input != "Revision")
            {
                string[] info = input
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);


                string shop = info[0];
                string product = info[1];
                double price = double.Parse(info[2]);

                if (!shopsInfo.ContainsKey(shop))
                {
                    shopsInfo[shop] = new Dictionary<string, double>();
                }

                if (!shopsInfo[shop].ContainsKey(product))
                {
                    shopsInfo[shop][product] = 0;
                }

                shopsInfo[shop][product] = price;

                input = Console.ReadLine();
            }

            foreach (var shop in shopsInfo)
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
