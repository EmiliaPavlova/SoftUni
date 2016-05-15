using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlusRemove
{
    class PlusRemove
    {
        static void Main(string[] args)
        {
            string input;
            var inputLines = new List<string>();
            var mask = new List<bool[]>();
            while ((input = Console.ReadLine()) != "END")
            {
                inputLines.Add(input);
                mask.Add(new bool[input.Length]);
            }
            for (int row = 1; row < inputLines.Count - 1; row++)
            {
                for (int col = 1; col < inputLines[row].Length - 1; col++)
                {
                    if (col < inputLines[row - 1].Length &&
                        col < inputLines[row + 1].Length &&
                        IsPlusShape(row, col, inputLines))
                    {
                        mask[row][col] = true;
                        mask[row][col - 1] = true;
                        mask[row][col + 1] = true;
                        mask[row - 1][col] = true;
                        mask[row + 1][col] = true;
                    }
                }
            }

            for (var row = 0; row < inputLines.Count; row++)
            {
                for (var col = 0; col < inputLines[row].Length; col++)
                {
                    if (mask[row][col]) continue;
                    Console.Write(inputLines[row][col]);
                }
                Console.WriteLine();
            }        
        }

        static bool IsPlusShape(int row, int col, List<string> arr)
        {
            var center = char.ToLower(arr[row][col]);
            var left = char.ToLower(arr[row][col - 1]);
            var right = char.ToLower(arr[row][col + 1]);
            var upper = char.ToLower(arr[row - 1][col]);
            var lower = char.ToLower(arr[row + 1][col]);

            var horizontalCheck = center == left && center == right;
            var verticalCheck = center == upper && center == lower;

            return horizontalCheck && verticalCheck;
        }
    }
}
