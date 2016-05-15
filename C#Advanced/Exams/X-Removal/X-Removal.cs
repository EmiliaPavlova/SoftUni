using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X_Removal
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            var inputLines = new List<string>();
            var xShapesSymbols = new List<bool[]>();
            while ((input = Console.ReadLine()) != "END")
            {
                inputLines.Add(input);
                xShapesSymbols.Add(new bool[input.Length]);
            }

            for (int row = 0; row < inputLines.Count - 2; row++)
            {
                for (int column = 2; column < inputLines[row].Length; column++)
                {
                    if (inputLines[row + 1].Length < column
                        || inputLines[row + 2].Length < column + 1)
                    {
                        continue;
                    }

                    char currentSymbol = char.ToLower(inputLines[row][column]);

                    if (char.ToLower(inputLines[row][column - 2]) == currentSymbol
                        && char.ToLower(inputLines[row + 1][column - 1]) == currentSymbol
                        && char.ToLower(inputLines[row + 2][column - 2]) == currentSymbol
                        && char.ToLower(inputLines[row + 2][column]) == currentSymbol)
                    {
                        xShapesSymbols[row][column - 2] = true;
                        xShapesSymbols[row][column] = true;
                        xShapesSymbols[row + 1][column - 1] = true;
                        xShapesSymbols[row + 2][column - 2] = true;
                        xShapesSymbols[row + 2][column] = true;
                    }
                }
            }

            for (var row = 0; row < inputLines.Count; row++)
            {
                for (var col = 0; col < inputLines[row].Length; col++)
                {
                    if (xShapesSymbols[row][col]) continue;
                    Console.Write(inputLines[row][col]);
                }
                Console.WriteLine();
            }        
        }
    }
}
