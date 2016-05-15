using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.SortArrayUsingSelectionSort
{
    class SortArrayOfNumbersUsingSelectionSort
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
            int temp = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i; j < numbers.Length; j++)
                {
                    if (numbers[i] > numbers[j])
                    {
                        temp = numbers[j];
                        numbers[j] = numbers[i];
                        numbers[i] = temp;
                    }
                }
                Console.Write(numbers[i]);
                Console.Write(" ");
            }
        }
    }
}
