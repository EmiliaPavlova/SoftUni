using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.LargerThanNeighbours
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                    .Trim()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(IsLargerThanNeighbours(numbers, i));
            }
        }

        static bool IsLargerThanNeighbours(int[] arr, int index)
        {
            if (index == 0)
            {
                if (arr[index] > arr[index + 1])
                {
                    return true;
                }
                return false;
            }
            if (index == (arr.Length - 1))
            {
                if (arr[index] > arr[index + 1])
                {
                    return true;
                }
                return false;
            }
            if (arr[index] > arr[index + 1] && arr[index] > arr[index - 1])
            {
                return true;
            }
            return false;
        }
    }
}
