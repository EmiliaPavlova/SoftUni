using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.FillTheMatrix
{
    class FillTheMatrix
    {
        private static void Main(string[] args)
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            int index = 1;
            int[,] matrix1 = new int[n, n];
            for (int col = 0; col < n; col++)
            {
                for (int row = 0; row < n; row++)
                {
                    matrix1[row, col] = index;
                    index++;
                }
            }

            int[,] matrix2 = new int[n, n];
            index = 1;
            for (int col = 0; col < n; col++)
            {
                if (col%2 == 0)
                {
                    for (int row = 0; row < n; row++)
                    {
                        matrix2[row, col] = index;
                        index++;
                    }
                }
                else
                {
                    for (int row = n - 1; row >= 0; row--)
                    {
                        matrix2[row, col] = index;
                        index++;
                    }
                }
            }

            Print(matrix1);
            Console.WriteLine();
            Print(matrix2);
        }

        private static void Print(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0,3}", matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
