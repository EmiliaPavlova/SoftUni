using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.MaximalSum
{
    class MaximalSum
    {
        static void Main(string[] args)
        {
            var sizes = Console.ReadLine()
                .Trim()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            int n = int.Parse(sizes[0]);
            int m = int.Parse(sizes[1]);
            int[,] matrix = new int[n, m];

            for (int row = 0; row < n; row++)
            {
                string[] rowOfMatrix = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = int.Parse(rowOfMatrix[col]);
                }
            }
            int bestSum = int.MinValue;
            int[,] matrixMaxSum = new int[3, 3];
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                              matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                              matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    if (sum > bestSum)
                    {
                        bestSum = sum;
                        for (int i = 0; i < matrixMaxSum.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrixMaxSum.GetLength(1); j++)
                            {
                                matrixMaxSum[i, j] = matrix[row + i, col + j];
                            }
                        }
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("Sum = {0}", bestSum);
            for (int row = 0; row < matrixMaxSum.GetLength(0); row++)
            {
                for (int col = 0; col < matrixMaxSum.GetLength(1); col++)
                {
                    Console.Write("{0,3}", matrixMaxSum[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
