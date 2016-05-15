using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.FirstLargerThanNeighbours
{
    class FirstLargerThanNeighbours
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                    .Trim()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            var largeNum = -1;
            for (int i = 0; i < numbers.Length; i++)
            {
                if(IsLargerThanNeighbours(numbers, i))
                {
                    largeNum = i;
                    break;
                }
            }

            Console.WriteLine(largeNum);
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
                if (arr[index] > arr[index - 1])
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
