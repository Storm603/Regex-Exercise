using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace T02._Race
{
    class Program
    {
        static void Main(string[] args)
        {

            string nameTemplate = @"(?<name>[A-Za-z]+)";
            string distanceTemplate = @"\d";

            Dictionary<string, int> playerInfo = new Dictionary<string, int>();

            string[] names = Console.ReadLine().Split(", ").ToArray();

            foreach (string name in names)
            {
                if (!playerInfo.ContainsKey(name))
                {
                    playerInfo.Add(name, 0);
                }
            }

            string input = Console.ReadLine();

            while (input != "end of race")
            {
                var currName = String.Empty;
                double currtotal = 0;

                MatchCollection name = Regex.Matches(input, nameTemplate);
                MatchCollection length = Regex.Matches(input, distanceTemplate);
                //currName = string.Join("", name); shortened way to make a string name

                foreach (Match number in length)
                {
                    currtotal += int.Parse(number.Value);
                }

                foreach (var letter in name)
                {
                    currName += letter;
                }

                if (playerInfo.ContainsKey(currName))
                {
                    playerInfo[currName] += (int)currtotal;
                }

                input = Console.ReadLine();
            }

            playerInfo = playerInfo.OrderByDescending(x => x.Value).Take(3).ToDictionary(x => x.Key, x => x.Value);

            var firstName = playerInfo.Take(1);
            var secondName = playerInfo.OrderByDescending(x => x.Value).Take(2).OrderBy(x => x.Value).Take(1);
            var thirdName = playerInfo.OrderBy(x => x.Value).Take(1);

            foreach (var firstPlace in firstName)
            {
                Console.WriteLine($"1st place: {firstPlace.Key}");
            }

            foreach (var secondPlace in secondName)
            {
                Console.WriteLine($"2nd place: {secondPlace.Key}");
            }

            foreach (var thirdPlace in thirdName)
            {
                Console.WriteLine($"3rd place: {thirdPlace.Key}");
            }
        }
    }
}
