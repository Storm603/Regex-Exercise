using System;
using System.Text.RegularExpressions;

namespace T06._Extracting_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex emailValidator = new Regex(@"(^|\s)[A-Za-z0-9][\w\.\-]*[a-zA-Z0-9]@[A-Za-z]+([.-][A-Za-z]+)+\b");

            string message = Console.ReadLine();

            MatchCollection validEmails = emailValidator.Matches(message);

            foreach (Match word in validEmails)
            {
                Console.WriteLine(word);
            }
        }
    }
}
