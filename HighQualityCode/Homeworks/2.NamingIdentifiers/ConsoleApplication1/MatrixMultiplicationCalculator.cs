using System;

namespace ConsoleApplication1
{
    class MatrixMultiplicationCalculator
    {
        static void Main(string[] args)
        {
            var firstMatrix = new double[,]
            {
                { 1, 3 }, 
                { 5, 7 }
            };

            var secondMatrix = new double[,]
            {
                { 4, 2 }, 
                { 1, 5 }
            };

            var resultMatrix = MultiplicateMatrices(firstMatrix, secondMatrix);

            for (int row = 0; row < resultMatrix.GetLength(0); row++)
            {
                for (int column = 0; column < resultMatrix.GetLength(1); column++)
                {
                    Console.Write(resultMatrix[row, column] + " ");
                }

                Console.WriteLine();
            }
        }

        private static double[,] MultiplicateMatrices(double[,] firstMatrix, double[,] secondMatrix)
        {
            if (firstMatrix.GetLength(1) != secondMatrix.GetLength(0))
            {
                throw new Exception("Error!");
            }

            var firstMatrixColumns = firstMatrix.GetLength(1);
            var resultMatrix = new double[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];
            for (int i = 0; i < resultMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < resultMatrix.GetLength(1); j++)
                {
                    for (int k = 0; k < firstMatrixColumns; k++)
                    {
                        resultMatrix[i, j] += firstMatrix[i, k]*secondMatrix[k, j];
                    }
                }
            }

            return resultMatrix;
        }
    }
}