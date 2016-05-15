namespace TargetPractice
{
    using System;

    class TargetPractice
    {
        static void Main(string[] args)
        {
            string[] dimensions = Console.ReadLine().Split(' ');
            int numberOfRows = int.Parse(dimensions[0]);
            int numberOfColumns = int.Parse(dimensions[1]);
            char[,] matrix = new char[numberOfRows, numberOfColumns];
            string snake = Console.ReadLine();

            FillMatrix(numberOfRows, numberOfColumns, snake, matrix);

            string[] shotArguments = Console.ReadLine().Split(' ');
            int impactRow = int.Parse(shotArguments[0]);
            int impactCol = int.Parse(shotArguments[1]);
            int radius = int.Parse(shotArguments[2]);

            FireAShot(matrix, impactRow, impactCol, radius);

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                RunGravity(matrix, col);
            }

            PrintMatrix(matrix);
        }

        private static void FillMatrix(int numberOfRows, int numberOfColumns, string snake, char[,] matrix)
        {
            bool isMovingLeft = true;
            int currentIndex = 0;

            for (int row = numberOfRows - 1; row >= 0; row--)
            {
                if (isMovingLeft)
                {
                    for (int col = numberOfColumns - 1; col >= 0; col--)
                    {
                        if (currentIndex >= snake.Length)
                        {
                            currentIndex = 0;
                        }

                        matrix[row, col] = snake[currentIndex];
                        currentIndex++;
                    }
                }
                else
                {
                    for (int col = 0; col < numberOfColumns; col++)
                    {
                        if (currentIndex >= snake.Length)
                        {
                            currentIndex = 0;
                        }

                        matrix[row, col] = snake[currentIndex];
                        currentIndex++;
                    }
                }

                isMovingLeft = !isMovingLeft;
            }
        }

        private static void FireAShot(char[,] matrix, int impactRow, int impactCol, int radius)
        {
            //(x - center_x)^2 + (y - center_y)^2 <= radius^2.
            for (int row = 0; row < matrix.GetLongLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLongLength(1); col++)
                {
                    if ((col - impactCol) * (col - impactCol) + (row - impactRow) * (row - impactRow) <= radius * radius)
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }
        }

        static void RunGravity(char[,] matrix, int col)
        {
            while (true)
            {
                bool hasFallen = false;

                for (int row = 1; row < matrix.GetLength(0); row++)
                {
                    char topChar = matrix[row - 1, col];
                    char currentChar = matrix[row, col];
                    if (currentChar == ' ' && topChar != ' ')
                    {
                        matrix[row, col] = topChar;
                        matrix[row - 1, col] = ' ';
                        hasFallen = true;
                    }
                }

                if (!hasFallen)
                {
                    break;
                }
            }
        }
        
        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLongLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLongLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
