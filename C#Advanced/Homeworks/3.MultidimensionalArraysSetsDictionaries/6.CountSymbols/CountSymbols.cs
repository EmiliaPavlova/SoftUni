using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.CountSymbols
{
    class CountSymbols
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            SortedDictionary<char, int> occurrences = new SortedDictionary<char, int>();
            foreach (char symbol in input)
            {
                if (occurrences.ContainsKey(symbol))
                {
                    occurrences[symbol]++;
                }
                else
                {
                    occurrences.Add(symbol, 1);
                }
            }

            foreach (KeyValuePair<char, int> pair in occurrences)
            {
                Console.WriteLine("{0}: {1} time/s", pair.Key, pair.Value);
            }
        }
    }
}
