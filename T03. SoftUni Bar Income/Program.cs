using System;
using System.Text.RegularExpressions;

namespace T03._SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {

            Regex regex = new Regex(@"^[^\|\$%\.]*?%(?<name>[A-Z][a-z]+)%[^\|\$%\.]*?<(?<product>\w+)>[^\|\$%\.]*?\|(?<count>\d+)\|[^\|\$%\.]*?(?<price>\d+(\.\d+)?)\$$");

            string order = Console.ReadLine();

            double totalPrice = 0;

            while (order != "end of shift")
            {
                Match validator = regex.Match(order);

                if (validator.Success)
                {
                    var name = validator.Groups["name"].Value;
                    var product = validator.Groups["product"].Value;
                    double count = double.Parse(validator.Groups["count"].Value);
                    double price = double.Parse(validator.Groups["price"].Value);
                    double currentProductPrice = count * price;
                    Console.WriteLine($"{name}: {product} - {currentProductPrice:f2}");
                    totalPrice += currentProductPrice;
                }

                order = Console.ReadLine();
            }
            Console.WriteLine($"Total income: {totalPrice:f2}");
        }
    }
}
