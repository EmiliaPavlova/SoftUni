using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.SortArrayOfNumbers
{
    class SortArrayOfNumbers
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] inputSplit = input.Split(' ');
            int[] numbers = new int[inputSplit.Length];
            for (int i = 0; i < inputSplit.Length; i++)
            {
                numbers[i] = int.Parse(inputSplit[i]);
            }
            Array.Sort(numbers);
            foreach (int number in numbers)
            {
                Console.Write(number);
                Console.Write(" ");
            }
        }
    }
}
