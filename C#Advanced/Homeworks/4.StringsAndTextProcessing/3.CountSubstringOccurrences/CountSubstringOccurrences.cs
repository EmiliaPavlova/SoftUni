using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _3.CountSubstringOccurrences
{
    class CountSubstringOccurrences
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = Console.ReadLine();
            int count = 0;
            int index = 0;
            while ((index = text.ToLower().IndexOf(pattern.ToLower(), index)) != -1)
            {
                index++;
                count++;
            }
            Console.WriteLine(count);
        }
    }
}
