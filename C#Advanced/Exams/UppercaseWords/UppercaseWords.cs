using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UppercaseWords
{
    class UppercaseWords
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"(?<![a-zA-Z])[A-Z]+(?![a-zA-Z])");
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var words = regex.Matches(input);
                foreach (Match match in words)
                {
                    string word = match.ToString();
                    int index = match.Index;
                    var replacement = IsPalindrome(word) ? GetRepeatedWord(word) : GetReversedWord(word);
                    Regex replacementRegex = new Regex(word);
                    input = replacementRegex.Replace(input, replacement, 1, index);
                }
                Console.WriteLine(SecurityElement.Escape(input));
            }
        }

        private static string GetReversedWord(string word)
        {
            return new string(word.ToCharArray().Reverse().ToArray());
        }

        private static string GetRepeatedWord(string word)
        {
            StringBuilder result = new StringBuilder(2 * word.Length);
            foreach (var symbol in word)
            {
                result.AppendFormat("{0}{0}", symbol);
            }
            return result.ToString();
        }

        private static bool IsPalindrome(string word)
        {
            string reversedWord = GetReversedWord(word);
            return reversedWord == word;
        }

    }
}
