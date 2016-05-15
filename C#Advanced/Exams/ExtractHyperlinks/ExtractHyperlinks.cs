using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _6.ExtractHyperlinks
{
    class ExtractHyperlinks
    {
        static void Main(string[] args)
        {
            string input;
            string pattern = @"<a\s+(?:[^>]+\s+)?href\s*=\s*(?:'([^']*)'|\""([^\""]*)|([^\s>]+))[^>]*>";
            StringBuilder line = new StringBuilder();
            string href;
            while ((input = Console.ReadLine()) != "END")
            {
                line.Append(input);
            }
            MatchCollection matches = Regex.Matches(line.ToString(), pattern);
            foreach (Match match in matches)
            {
                href = match.Groups[1].ToString();
                if (match.Groups[1].ToString() == "")
                {
                    href = match.Groups[2].ToString();
                    if (match.Groups[2].ToString() == "")
                    {
                        href = match.Groups[3].Value;
                    }
                }
                Console.WriteLine(href);
            }
        }
    }
}
