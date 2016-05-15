using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RageQuit
{
    class RageQuit
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            foreach (Match match in Regex.Matches(input, (@"([^0-9]+)([0-9]+)")))
            {
                var str = match.Groups[1].Value;
                int integer = int.Parse(match.Groups[2].Value);
                StringBuilder part = new StringBuilder();
                for (int i = 0; i < integer; i++)
                {
                    part.Append(str);
                }
                sb.Append(part);
            }
            string count = new String(sb.ToString().ToUpper().Distinct().ToArray());
            Console.WriteLine("Unique symbols used: " + count.Length);
            Console.WriteLine(sb.ToString().ToUpper());
        }
    }
}
