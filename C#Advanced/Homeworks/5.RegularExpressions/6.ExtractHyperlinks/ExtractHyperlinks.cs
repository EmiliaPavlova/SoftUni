using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _6.ExtractHyperlinks
{
    internal class ExtractHyperlinks
    {
        private static void Main(string[] args)
        {
            string input;
            string href;
            StringBuilder html = new StringBuilder();
            while (!((input = Console.ReadLine()) == "END"))
            {
                html.Append(input);
            }
            string pattern = "<a\\s+(?:[^>]+\\s+)?href\\s*=\\s*(?:'([^']*)'|\"([^\"]*)|([^\\s>]+))[^>]*>";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(html.ToString());
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