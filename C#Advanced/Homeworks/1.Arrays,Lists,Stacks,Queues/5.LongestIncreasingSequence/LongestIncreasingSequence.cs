using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.LongestIncreasingSequence
{
    class LongestIncreasingSequence
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int currentLength = 1;
            int longestLength = 1;
            int bestPosition = 0;
            int startPosition = 0;

            Console.Write(numbers[0]);
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > numbers[i - 1])
                {
                    Console.Write(" " + numbers[i]);
                    currentLength++;
                }
                else
                {
                    Console.WriteLine();
                    Console.Write(numbers[i]);
                    currentLength = 1;
                }

                if (currentLength > longestLength)
                {
                    longestLength = currentLength;
                    bestPosition = i;
                    startPosition = i - (longestLength - 1);
                }
            }
            Console.WriteLine();
            Console.Write("Longest: ");
            for (int i = startPosition; i <= bestPosition; i++)
            {
                Console.Write(numbers[i] + " ");
            }
        }
    }
}
