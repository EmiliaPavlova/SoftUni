namespace ClearingCommands
{
    using System;
    using System.Collections.Generic;
    using System.Security;

    class ClearingCommands
    {
        static void Main(string[] args)
        {
            string commandSymbols = "><^v";
            List<char[]> matrix = new List<char[]>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                matrix.Add(input.Trim().ToCharArray());
            }
            for (int row = 0; row < matrix.Count; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    int currentRow;
                    int currentCol;
                    switch (matrix[row][col])
                    {
                        case '<':
                            currentRow = row;
                            currentCol = col - 1;
                            while (currentCol >= 0 && !commandSymbols.Contains(matrix[currentRow][currentCol].ToString()))
                            {
                                matrix[currentRow][currentCol] = ' ';
                                currentCol--;
                            }
                            break;
                        case '>':
                            currentRow = row;
                            currentCol = col + 1;
                            while (currentCol < matrix[currentRow].Length && !commandSymbols.Contains(matrix[currentRow][currentCol].ToString()))
                            {
                                matrix[currentRow][currentCol] = ' ';
                                currentCol++;
                            }
                            break;
                        case 'v':
                            currentRow = row + 1;
                            currentCol = col;
                            while (currentRow < matrix.Count && !commandSymbols.Contains(matrix[currentRow][currentCol].ToString()))
                            {
                                matrix[currentRow][currentCol] = ' ';
                                currentRow++;
                            }
                            break;
                        case '^':
                            currentRow = row - 1;
                            currentCol = col;
                            while (currentRow >= 0 && !commandSymbols.Contains(matrix[currentRow][currentCol].ToString()))
                            {
                                matrix[currentRow][currentCol] = ' ';
                                currentRow--;
                            }
                            break;
                    }
                }
            }
            for (int row = 0; row < matrix.Count; row++)
            {
                Console.WriteLine("<p>{0}</p>", SecurityElement.Escape(new string(matrix[row])));
            }
        }
    }
}
