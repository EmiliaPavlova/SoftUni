using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.SortedSubsetSums
{
    class SortedSubsetSums
    {
        private static int[] numbers;
        private static int sum;
        private static bool hasSubset = false;
        private static List<List<int>> foundSubsets = new List<List<int>>();
        
        static void Main(string[] args)
        {
            Console.Write("number: ");
            sum = int.Parse(Console.ReadLine());
            Console.Write("integers: ");
            numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            List<int> subset = new List<int>();
            
            FindSubsets(0, subset);

            if (!hasSubset)
            {
                Console.WriteLine("No matching subsets.");
            }
            else
            {
                foundSubsets = foundSubsets.OrderBy(x => x.Count).ToList();
                foreach (var subsets in foundSubsets)
                {
                    Console.WriteLine("{0} = {1}", string.Join(" + ", subsets), sum);
                }
            }
        }

        static void FindSubsets(int index, List<int> subsets)
        {
            if (subsets.Sum() == sum && subsets.Count > 0)
            {
                subsets = subsets.OrderBy(x => x.ToString().Length).ToList();
                //Console.WriteLine("{0} = {1}", string.Join(" + ", subsets), sum);
                foundSubsets.Add(subsets);
                hasSubset = true;
            }
            for (int i = index; i < numbers.Length; i++)
            {
                subsets.Add(numbers[i]);
                FindSubsets(i + 1, subsets);
                subsets.RemoveAt(subsets.Count - 1);
            }
        }
    }
}
