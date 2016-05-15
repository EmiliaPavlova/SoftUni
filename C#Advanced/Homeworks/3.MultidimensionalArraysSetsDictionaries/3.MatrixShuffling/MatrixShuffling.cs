using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.MatrixShuffling
{
    class MatrixShuffling
    {
        private static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            string[,] matrix = new string[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = Console.ReadLine();
                }
            }

            //int x1 = 0;
            //int y1 = 0;
            //int x2 = 0;
            //int y2 = 0;
            string temp = "";
            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] input = command
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                if (input.Length == 5 && input[0] == "swap")
                {
                    int x1 = int.Parse(input[1]);
                    int y1 = int.Parse(input[2]);
                    int x2 = int.Parse(input[3]);
                    int y2 = int.Parse(input[4]);

                    if ((x1 >= 0 && x1 < rows) && (y1 >= 0 && y1 < cols) && 
                        (x2 >= 0 && x2 < rows) && (y2 >= 0 && y2 < cols))
                    {
                        temp = matrix[x1, y1];
                        matrix[x1, y1] = matrix[x2, y2];
                        matrix[x2, y2] = temp;

                        Console.WriteLine();
                        Console.WriteLine("After swapping {0} and {1}: ", matrix[x2, y2], matrix[x1, y1]);
                        for (int row = 0; row < rows; row++)
                        {
                            for (int col = 0; col < cols; col++)
                            {
                                Console.Write("{0,2} ", matrix[row, col]);
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Invalid input!");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine(); 
                    Console.WriteLine("Invalid input!");
                    Console.WriteLine();
                }

                command = Console.ReadLine();
            }
        }
    }
}