using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringMatrixRotation
{
    class StringMatrixRotation
    {
        static void Main(string[] args)
        {
            string input;
            var maxLength = 0;
            var degreesString = Console.ReadLine();
            degreesString = Regex.Replace(degreesString, @"[^0-9]", "");
            int degrees = int.Parse(degreesString) % 360;
            List<string> lines = new List<string>();

            while ((input = Console.ReadLine()) != "END")
            {
                lines.Add(input);
            }
            for (var i = 0; i < lines.Count; i++)
            {
                while (lines[i].Length > maxLength)
                {
                    maxLength = lines[i].Length;
                }
            }
            char[,] matrix = buildMatrix(lines, lines.Count, maxLength);
            switch (degrees % 360)
            {
                case 0: PrintMatrix(matrix); break;
                case 90: Rotate90(matrix); break;
                case 180: Rotate180(matrix); break;
                case 270: Rotate270(matrix); break;
            }
        }

        static char[,] buildMatrix(List<string> source, int N, int M)
        {
            var result = new char[N, M];
            for (int i = 0; i < N; ++i)
            {
                for (int j = 0; j < M; ++j)
                {
                    result[i, j] = source[i].PadRight(M, ' ')[j];
                }
            }
            return result;
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void Rotate90(char[,] matrix)
        {
            for (int rows = 0; rows < matrix.GetLength(1); rows++)
            {
                for (int cols = matrix.GetLength(0) - 1; cols >= 0; cols--)
                {
                    Console.Write(matrix[cols, rows]);
                }
                Console.WriteLine();
            }
        }

        private static void Rotate180(char[,] matrix)
        {
            for (int rows = matrix.GetLength(0) - 1; rows >= 0; rows--)
            {
                for (int cols = matrix.GetLength(1) - 1; cols >= 0; cols--)
                {
                    Console.Write(matrix[rows, cols]);
                }
                Console.WriteLine();
            }
        }

        private static void Rotate270(char[,] matrix)
        {
            for (int rows = matrix.GetLength(1) - 1; rows >= 0; rows--)
            {
                for (int cols = 0; cols < matrix.GetLength(0); cols++)
                {
                    Console.Write(matrix[cols, rows]);
                }
                Console.WriteLine();
            }
        }
    }
}
