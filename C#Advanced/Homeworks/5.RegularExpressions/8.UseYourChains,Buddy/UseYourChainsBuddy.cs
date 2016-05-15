using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _8.UseYourChains_Buddy
{
    class UseYourChainsBuddy
    {
        static void Main(string[] args)
        {
            string regex = @"<p>(.*?)<\/p>";
            var input = Regex.Matches(Console.ReadLine(), regex);
            string output = String.Empty;
            foreach (Match match in input)
            {
                string text = match.Groups[1].Value;
                foreach (var ch in text)
                {
                    if (ch >= 'a' && ch <= 'm')
                    {
                        output += (char) (ch + 13);
                    }
                    else if (ch >= 'n' && ch <= 'z')
                    {
                        output += (char)(ch - 13);
                    }
                    else if (ch >= '0' && ch <= '9')
                    {
                        output += ch;
                    }
                    else
                    {
                        output += " ";
                    }
                }
            }
            Regex whitespaceRegex = new Regex("\\s+");
            output = whitespaceRegex.Replace(output, " ");
            Console.WriteLine(output);
        }
    }
}
