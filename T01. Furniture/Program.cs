using System;
using System.Text.RegularExpressions;

namespace T01._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {

            string template = @">>(?<Name>[A-Za-z\s]+?)<<(?<price>\d+(.\d+)?)!(?<quantity>\d+)";

            string input = Console.ReadLine();

            double totalPrice = 0;

            Console.WriteLine("Bought furniture:");

            while (input != "Purchase")
            {
                Match matchedFurniture = Regex.Match(input, template, RegexOptions.IgnoreCase);

                if (matchedFurniture.Success)
                {
                    Console.WriteLine(matchedFurniture.Groups["Name"].Value);
                    var price = double.Parse(matchedFurniture.Groups["price"].Value);
                    var quantity = double.Parse(matchedFurniture.Groups["quantity"].Value);
                    totalPrice += price * quantity;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Total money spend: {totalPrice:f2}");
        }
    }
}
