using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace T04._Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex template =
                new Regex(
                    @"@[^@\-!:>]*?(?<name>[A-Z][a-z]+)[^@\-!:>]*?:[^@\-!:>]*?(?<population>[0-9]+)[^@\-!:>]*?![^@\-!:>]*?(?<attacktype>[A|D])[^@\-!:>]*?![^@\-!:>]*?->[^@\-!:>]*?(?<soldiercount>[0-9]+)[^@\-!:>]*?$\b");

            int numberOfMessages = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> planetDictionary = new Dictionary<string, List<string>>();
            planetDictionary.Add("A", new List<string>());
            planetDictionary.Add("D", new List<string>());

            for (int i = 0; i < numberOfMessages; i++)
            {
                string message = Console.ReadLine();
                string lowered = message.ToLower();

                int count = 0;

                string converted = String.Empty;

                foreach (char letter in lowered)
                {
                    if (letter == 's' || letter == 't' || letter == 'a' || letter == 'r')
                    {
                        count++;
                    }
                }


                foreach (char letter in message)
                {
                    int calc = letter - count;
                    char currChar = (char) calc;
                    converted += currChar.ToString();
                }

                Match msg = template.Match(converted);

                if (msg.Success)
                {
                    string name = msg.Groups["name"].Value;
                    string type = msg.Groups["attacktype"].Value;

                    if (type == "A")
                    {
                        planetDictionary[type].Add(name);
                    }
                    else
                    {
                        planetDictionary[type].Add(name);
                    }
                }

            }


            foreach (KeyValuePair<string, List<string>> atktype in planetDictionary)
            {
                atktype.Value.Sort();
            }

            Console.WriteLine($"Attacked planets: {planetDictionary["A"].Count}");

            foreach (var planet in planetDictionary["A"])
            {
                Console.WriteLine($"-> {planet}");
            }

            Console.WriteLine($"Destroyed planets: {planetDictionary["D"].Count}");

            foreach (var planet in planetDictionary["D"])
            {
                Console.WriteLine($"-> {planet}");
            }
        }
    }
}
