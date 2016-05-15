using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.SubsetSums
{
    class SubsetSums
    {
        private static int[] numbers;
        private static int sum;
        private static bool hasSubset = false;

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
        }

        static void FindSubsets(int index, List<int> subsets)
        {
            if (subsets.Sum() == sum && subsets.Count > 0)
            {
                Console.WriteLine("{0} = {1}", string.Join(" + ", subsets), sum);
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