using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text.RegularExpressions;

namespace T02._Ad_Astra
{
    class Program
    {
        static void Main(string[] args)
        {
            string information = Console.ReadLine();

            Regex template = new Regex(@"([\|\#])(?<foodName>[A-Za-z\s]+)(\1)(?<validTill>[0-9]{2}\/[0-9]{2}\/[0-9]{2})(\1)(?<calories>[0-9]+)(\1)");

            Dictionary<string, List<string>> foodSupplies = new Dictionary<string, List<string>>();

            MatchCollection foodInfo = template.Matches(information);


            int caloriesTotal = 0;

            foreach (Match item in foodInfo)
            {

                string currCalories = item.Groups["calories"].Value;

                int calories = int.Parse(currCalories);

                caloriesTotal += calories;

            }


            int foodForDaysCalc = (caloriesTotal / 2000);

            Console.WriteLine($"You have food to last you for: {foodForDaysCalc} days!");


            foreach (Match item in foodInfo)
            {
                Console.WriteLine($"Item: {item.Groups["foodName"].Value}, Best before: {item.Groups["validTill"].Value}, Nutrition: {item.Groups["calories"].Value}");
            }

        }
    }
}
