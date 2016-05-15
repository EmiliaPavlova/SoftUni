using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoBlocks
{
    class LegoBlocks
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] firstJagged = new int[n][];
            int[][] secondJagged = new int[n][];

            for (int i = 0; i < n; i++)
            {
                firstJagged[i] = Console.ReadLine()
                    .Trim()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }
            for (int i = 0; i < n; i++)
            {
                secondJagged[i] = Console.ReadLine()
                    .Trim()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }
            //check
            bool matching = true;
            int combinedLength = firstJagged[0].Length + secondJagged[0].Length;
            for (int i = 1; i < n; i++)
            {
                int nextLength = firstJagged[i].Length + secondJagged[i].Length;
                if (nextLength != combinedLength)
                {
                    matching = false;
                    break;
                }
            }
            //print accordingly
            if (matching)
            {
                for (int i = 0; i < n; i++)
                {
                    String output = "";
                    for (int j = 0; j < firstJagged[i].Length; j++)
                    {
                        output += firstJagged[i][j] + ", ";
                    }
                    for (int j = secondJagged[i].Length - 1; j >= 0; j--)
                    {
                        output += secondJagged[i][j] + ", ";
                    }
                    Console.WriteLine("[" + output.Substring(0, output.Length - 2) + "]");
                }
            }
            else
            {
                int totalLength = 0;
                for (int i = 0; i < n; i++)
                {
                    totalLength += firstJagged[i].Length + secondJagged[i].Length;
                }
                Console.WriteLine("The total number of cells is: " + totalLength);
            }
        }
    }
}
