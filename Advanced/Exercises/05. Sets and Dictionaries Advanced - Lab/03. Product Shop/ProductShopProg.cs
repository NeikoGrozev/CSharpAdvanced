namespace ProductShop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ProductShopProg
    {
        static void Main()
        {
            Dictionary<string, Dictionary<string, double>> shops = new Dictionary<string, Dictionary<string, double>>();


            while (true)
            {
                string[] tokens = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string shop = tokens[0];

                if (shop == "Revision")
                {
                    break;
                }

                string product = tokens[1];
                double price = double.Parse(tokens[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops.Add(shop, new Dictionary<string, double>());
                    shops[shop].Add(product, price);
                }
                else
                {
                    if (!shops[shop].ContainsKey(product))
                    {
                        shops[shop].Add(product, price);
                    }
                    else
                    {
                        shops[shop][product] = price;
                    }
                }

            }

            foreach (var shop in shops.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var item in shop.Value)
                {
                    Console.WriteLine($"Product: {item.Key}, Price: {item.Value}");
                }
            }
        }
    }
}
