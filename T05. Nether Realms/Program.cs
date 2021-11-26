using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace T05._Nether_Realms
{
    class Program
    {
        static void Main(string[] args)
        {
            string letters = @"[^0-9\+\-\*\/\.\, ]";
            string numbers = @"-?\d+?\.?\d+|[0-9]+";
            string dividers = @"[\*\/]";
            string splitter = @"[,\s]+";

            string input = Console.ReadLine();
            string[] demonInput = Regex.Split(input, splitter).OrderBy(x => x).ToArray();

             

            for (int i = 0; i < demonInput.Length; i++)
            {
                string demon = demonInput[i];

                long health = 0;
                double damage = 0;

                MatchCollection leter = Regex.Matches(demon, letters);
                foreach (Match letter in leter)
                {
                    health += char.Parse(letter.Value);
                }

                MatchCollection numberos = Regex.Matches(demon, numbers);
                foreach (Match numbero in numberos)
                {
                    string symbol = numbero.ToString();

                    damage += double.Parse(symbol);
                }

                MatchCollection div = Regex.Matches(input, dividers);
                foreach (Match symbol in div)
                {
                    char sym = char.Parse(symbol.ToString());
                    if (sym == '*')
                    {
                        damage *= 2;
                    }
                    else
                    {
                        damage /= 2;
                    }
                }

                Console.WriteLine($"{demon} - {health} health, {damage:f2} damage");
            }
        }
    }
}
