using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _7.QueryMess
{
    class QueryMess
    {
        static void Main(string[] args)
        {
            string input;
            string pattern = @"([^=&?]+)=([^=&?]+)";
            string whitespace = @"\s+";
            Regex whitespaceRegex = new Regex(whitespace);
            MatchCollection matches;
            var keyObject = new Dictionary<string, List<string>>();
            while ((input = Console.ReadLine()) != "END")
            {
                input = input.Replace("%20", " ").Replace("+", " ");
                input = whitespaceRegex.Replace(input, " ");
                matches = Regex.Matches(input, pattern);
                foreach (Match match in matches)
                {
                    string key = match.Groups[1].Value.Trim();
                    string value = match.Groups[2].Value.Trim();
                    if (!keyObject.ContainsKey(key))
                    {
                        keyObject.Add(key, new List<string>());
                    }
                    keyObject[key].Add(value);
                }
                foreach (var key in keyObject.Keys)
                {
                    Console.Write("{0}=[{1}]", key, string.Join(", ", keyObject[key]));
                }
                Console.WriteLine();
                keyObject.Clear();
            }
        }
    }
}
