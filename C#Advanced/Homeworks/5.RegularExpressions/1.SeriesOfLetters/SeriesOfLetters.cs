using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _1.SeriesOfLetters
{
    class SeriesOfLetters
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            foreach (char ch in input)
            {
                Regex equalChars = new Regex(ch + "+");
                input = equalChars.Replace(input, ch.ToString());
            }
            Console.WriteLine(input);
        }
    }
}
