using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.CollectTheCoins
{
    class CollectTheCoins
    {
        static void Main(string[] args)
        {
            string[] board = new string[4];
 
            string boardLine = String.Empty;
            for (int row = 0; row < board.GetLength(0); row++)
            {
                board[row] = Console.ReadLine();
            }
            int currentRow = 0;
            int currentCol = 0;
            int counterCoins = 0;
            int hitWalls = 0;
            string move = Console.ReadLine();
            foreach (char currentDirection in move)
            {
                if (currentDirection == 'V')
                {
                    currentRow++;
                    if (currentRow >= board.GetLength(0))
                    {
                        currentRow--;
                        hitWalls++;
                        continue;
                    }
                    else if (currentCol >= board[currentRow].Length)
                    {
                        currentRow--;
                        hitWalls++;
                        continue;
                    }
                }
                else if (currentDirection == '>')
                {
                    currentCol++;
                    if (currentCol >= board[currentRow].Length)
                    {
                        currentCol--;
                        hitWalls++;
                        continue;
                    }
                }
                else if (currentDirection == '<')
                {
                    currentCol--;
                    if (currentCol < 0)
                    {
                        currentCol++;
                        hitWalls++;
                        continue;
                    }
                }
                else if (currentDirection == '^')
                {
                    currentRow--;
                    if (currentRow < 0)
                    {
                        currentRow++;
                        hitWalls++;
                        continue;
                    }
                    else if (currentCol >= board[currentRow].Length)
                    {
                        currentRow++;
                        hitWalls++;
                        continue;
                    }
                }
 
                if (board[currentRow][currentCol].Equals('$'))
                {
                    counterCoins++;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Coins collected: {0}", counterCoins);
            Console.WriteLine("Walls hit: {0}", hitWalls);
        }
    }
}
