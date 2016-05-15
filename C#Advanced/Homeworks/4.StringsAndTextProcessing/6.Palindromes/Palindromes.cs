using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _6.Palindromes
{
    class Palindromes
    {
        static void Main(string[] args)
        {
            var words = Regex.Split(Console.ReadLine(), @"\s*[\s+,\.?!]\s*")
                .ToList();
            SortedSet<string> palindromes= new SortedSet<string>();
            words.ForEach(word =>
            {
                if (IsPalidrome(word))
                {
                    palindromes.Add(word);
                }
            });
            Console.WriteLine(string.Join(", ", palindromes));
        }

        private static bool IsPalidrome(string word)
        {
            int length = word.Length;
            for (int i = 0; i < length; i++)
            {
                if (word[i] != word[length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
