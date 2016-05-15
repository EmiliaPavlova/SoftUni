namespace Parachute
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Parachute
    {
        static void Main(string[] args)
        {
            List<string> matrix = new List<string>();
            string input;
            int row = 0;
            int col = 0;
            bool found = false;
            while ((input = Console.ReadLine()) != "END")
            {
                if (input.Contains("o"))
                {
                    col = input.IndexOf("o");
                    found = true;
                }
                else if (!found)
                {
                    row++;
                }
                matrix.Add(input);
            }
            while (true)
            {
                row++;
                col -= matrix[row].Count(symbol => symbol == '<');
                col += matrix[row].Count(symbol => symbol == '>');
                if (matrix[row][col] == '_')
                {
                    Console.WriteLine("Landed on the ground like a boss!");
                    break;
                }
                if (matrix[row][col] == '~')
                {
                    Console.WriteLine("Drowned in the water like a cat!");
                    break;
                }
                if (matrix[row][col] == '\\' || 
                    matrix[row][col] == '/' || 
                    matrix[row][col] == '|')
                {
                    Console.WriteLine("Got smacked on the rock like a dog!");
                    break;
                }
            }
            Console.WriteLine("{0} {1}", row, col);
        }
    }
}
