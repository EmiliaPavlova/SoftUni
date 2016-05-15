namespace MatrixShuffle
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    class MatrixShuffle
    {
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());
            var text = Console.ReadLine();
            var matrix = new char[size, size];

            int limit = text.Length;
            int index = 0;
            int row = 0;
            int col = 0;
            while (index < limit)
            {
                while (col < size && matrix[row, col] == 0)
                {
                    matrix[row, col] = text[index];
                    col++;
                    index++;
                }
                row++;
                col--;
                while (row < size && matrix[row, col] == 0)
                {
                    matrix[row, col] = text[index];
                    row++;
                    index++;
                }
                row--;
                col--;
                while (col >= 0 && matrix[row, col] == 0)
                {
                    matrix[row, col] = text[index];
                    col--;
                    index++;
                }
                col++;
                row--;
                while (row >= 0 && matrix[row, col] == 0)
                {
                    matrix[row, col] = text[index];
                    row--;
                    index++;
                }
                row++;
                col++;
            }
            string sentence = GetSentence(matrix, true);
            sentence += GetSentence(matrix, false);
            string reversedSentence = GetRevercedString(sentence);

            if (IsPalindrome(sentence, reversedSentence))
            {
                Console.WriteLine("<div style='background-color:#4FE000'>{0}</div>", sentence);
            }
            else
            {
                Console.WriteLine("<div style='background-color:#E0000F'>{0}</div>", sentence);
            }
        }

        static string GetSentence(char[,] matrix, bool isWhite)
        {
            string output = string.Empty;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (isWhite && (col % 2 == 0))
                    {
                        output += matrix[row, col];
                    }
                    else if (!isWhite && (col % 2 == 1))
                    {
                        output += matrix[row, col];
                    }
                }
                isWhite = !isWhite;
            }
            return output;
        }

        static string GetRevercedString(string input)
        {
            var letters = input.ToCharArray();
            letters = letters.Reverse().ToArray();
            return new string(letters);
        }

        static bool IsPalindrome(string input, string reversed)
        {
            input = Regex.Replace(input, @"[^a-zA-Z]", "").ToLower();
            reversed = Regex.Replace(reversed, @"[^a-zA-Z]", "").ToLower();
            return input == reversed;
        }
    }
}
