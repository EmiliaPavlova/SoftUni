using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.SequenceInMatrix
{
    class SequenceInMatrix
    {
        private static void Main(string[] args)
        {
            Console.Write("rows: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("columns: ");
            int m = int.Parse(Console.ReadLine());
            string[,] matrix = new string[n, m];
            Console.WriteLine("Enter strings by rows and columns: ");
            for (int row = 0; row < n; row++)
            {
                string[] rowOfMatrix = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = rowOfMatrix[col];
                }
            }
            int lenght = 1;
            int bestLength = 1;
            string sameString = "";
            string outputString = "";
            for (int row = 0; row < n - 1; row++)
            {
                for (int col = 0; col < m - 1; col++)
                {
                    if ((matrix[row, col].Equals(matrix[row, col + 1])) ||
                        (matrix[row, col].Equals(matrix[row + 1, col])) ||
                        (matrix[row, col].Equals(matrix[row + 1, col + 1])) ||
                        (col > 0 && matrix[row, col].Equals(matrix[row + 1, col - 1])))
                    {
                        sameString = matrix[row, col];
                        lenght++;

                        if (lenght > bestLength)
                        {
                            bestLength = lenght;
                            outputString = sameString;
                        }
                    }
                }
            }
            lenght = 1;
            sameString = String.Empty;
            for (int row = 0; row < n - 1; row++)
            {
                if (matrix[row, m - 1].Equals(matrix[row + 1, m - 1]))
                {
                    sameString = matrix[row, m - 1];
                    lenght++;

                    if (lenght > bestLength)
                    {
                        bestLength = lenght;
                        outputString = sameString;
                    }
                }
            }
            Console.WriteLine();
            for (int i = 0; i < bestLength-1; i++)
            {
                Console.Write("{0}, ", outputString);
            }
            Console.WriteLine(outputString);
        }
    }
}