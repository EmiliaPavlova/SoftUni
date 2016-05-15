using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _4.SentenceExtractor
{
    class SentenceExtractor
    {
        static void Main(string[] args)
        {
            string keyword = Console.ReadLine();
            string text = Console.ReadLine();
            string pattern = @"[\s\S]*?\b" + keyword + @"\b[\s\S]*?[?\.!]";
            MatchCollection matches = Regex.Matches(text, pattern);

            Console.WriteLine();
            foreach (Match match in matches)
            {
                Console.WriteLine(match.ToString().Trim());
            }
        }
    }
}
