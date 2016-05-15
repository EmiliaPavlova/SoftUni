namespace TextGravity
{
    using System;
    using System.Collections.Generic;
    using System.Security;

    class TextGravity
    {
        static void Main(string[] args)
        {
            var length = int.Parse(Console.ReadLine());
            var text = Console.ReadLine();
            int index = 0;
            List<char[]> matrix = new List<char[]>();
            while (index < text.Length)
            {
                char[] currentLine = new char[length];
                for (int i = 0; i < length; i++)
                {
                    if (index < text.Length)
                    {
                        currentLine[i] = text[index];
                    }
                    else
                    {
                        currentLine[i] = ' ';
                    }
                    index++;
                }
                matrix.Add(currentLine);
            }
            for (int row = matrix.Count - 1; row >= 0; row--)
            {
                for (int column = 0; column < length; column++)
                {
                    if (matrix[row][column] != ' ')
                    {
                        continue;
                    }
                    int currentRow = row - 1;
                    while (currentRow >= 0)
                    {
                        if (matrix[currentRow][column] != ' ')
                        {
                            matrix[row][column] = matrix[currentRow][column];
                            matrix[currentRow][column] = ' ';
                            break;
                        }
                        currentRow--;
                    }
                }
            }
            Console.Write("<table>");
            for (int row = 0; row < matrix.Count; row++)
            {
                Console.Write("<tr>");
                for (int column = 0; column < length; column++)
                {
                    Console.Write("<td>{0}</td>", SecurityElement.Escape(matrix[row][column].ToString()));
                }
                Console.Write("</tr>");
            }
            Console.WriteLine("</table>");
        }
    }
}
