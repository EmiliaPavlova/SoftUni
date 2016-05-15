using System;

namespace BunkerBuster
{
    class BunkerBuster
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split();
            int rows = int.Parse(dimensions[0]);
            int cols = int.Parse(dimensions[1]);

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var numbers = Console.ReadLine().Split();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = int.Parse(numbers[col]);
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "cease fire!")
            {
                var bombData = input.Split();
                int impactRow = int.Parse(bombData[0]);
                int impactCol = int.Parse(bombData[1]);
                string impactPower = bombData[2];
                int power = Char.Parse(impactPower);
                decimal half = Math.Ceiling((decimal)power / 2);
                int halfPower = (int)half;

                matrix[impactRow, impactCol] -= power;
                if (impactRow - 1 >= 0 && impactCol - 1 >= 0)
                {
                    matrix[impactRow - 1, impactCol - 1] -= halfPower;
                }
                if (impactRow - 1 >= 0)
                {
                    matrix[impactRow - 1, impactCol] -= halfPower;
                }
                if (impactRow - 1 >= 0 && impactCol + 1 < cols)
                {
                    matrix[impactRow - 1, impactCol + 1] -= halfPower;
                }
                if (impactCol - 1 >= 0)
                {
                    matrix[impactRow, impactCol - 1] -= halfPower;
                }
                if (impactCol + 1 < cols)
                {
                    matrix[impactRow, impactCol + 1] -= halfPower;
                }
                if (impactRow + 1 < rows && impactCol - 1 >= 0)
                {
                    matrix[impactRow + 1, impactCol - 1] -= halfPower;
                }
                if (impactRow + 1 < rows)
                {
                    matrix[impactRow + 1, impactCol] -= halfPower;
                }
                if (impactRow + 1 < rows && impactCol + 1 < cols)
                {
                    matrix[impactRow + 1, impactCol + 1] -= halfPower;
                }

            }

            Console.WriteLine("Destroyed bunkers: {0}", CheckMatrix(matrix));
            Console.WriteLine("Damage done: {0:F1} %", (decimal)CheckMatrix(matrix) * 100 / (rows * cols));
            //PrintMatrix(matrix);
        }


        private static int CheckMatrix(int[,] matrix)
        {
            int destroyed = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] <= 0)
                    {
                        destroyed++;
                    }
                }
            }
            return destroyed;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0,4}", matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
