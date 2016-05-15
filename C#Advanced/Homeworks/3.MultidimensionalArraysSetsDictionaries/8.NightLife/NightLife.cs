using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.NightLife
{
    class NightLife
    {
        static void Main(string[] args)
        {
            Dictionary<string, SortedDictionary<string, SortedSet<string>>> nightLife = new Dictionary<string, SortedDictionary<string, SortedSet<string>>>();

            string data = Console.ReadLine();

            while (data != "END")
            {
                string[] input = data.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                string city = input[0];
                string venue = input[1];
                string performer = input[2];

                if (!nightLife.ContainsKey(city))
                {
                    nightLife[city] = new SortedDictionary<string, SortedSet<string>>();
                }
                if (!nightLife[city].ContainsKey(venue))
                {
                    nightLife[city][venue] = new SortedSet<string>();
                }
                nightLife[city][venue].Add(performer);
                data = Console.ReadLine();
            }
            Console.WriteLine();
            foreach (var printCity in nightLife)
            {
                Console.WriteLine(printCity.Key);
                foreach (var printVenue in printCity.Value)
                {
                    Console.WriteLine("->{0}: {1}", printVenue.Key, String.Join(", ", printVenue.Value));
                }
            }
        }
    }
}
