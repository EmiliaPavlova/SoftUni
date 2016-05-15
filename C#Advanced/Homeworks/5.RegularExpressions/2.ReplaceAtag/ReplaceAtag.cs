using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _2.ReplaceAtag
{
    class ReplaceAtag
    {
        static void Main(string[] args)
        {
            //string input = Console.ReadLine();
            string input = "<ul><li><a href=http://softuni.bg>SoftUni</a></li></ul>";
            string pattern = @"([\s\S]*?)<a\s*href\s*=(.*?)>([\s\S]*?)<\/a>([\s\S]*)";
            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[1].Value + "[URL href=" + match.Groups[2] + "]" + match.Groups[3] + "[/URL]");
            }
        }
    }
}
