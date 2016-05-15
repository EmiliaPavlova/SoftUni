using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _5.ValidUsernames
{
    class ValidUsernames
    {
        static void Main(string[] args)
        {
            var usernames = Regex.Matches(Console.ReadLine(), @"\b[a-zA-Z][\w+]{3,25}\b");
            int maxLength = 0;
            string[] longestTwoWords = new string[2];
            for (int i = 0; i < usernames.Count - 1; i++)
            {
                int currentLength = usernames[i].Length + usernames[i + 1].Length;
                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                    longestTwoWords[0] = usernames[i].ToString();
                    longestTwoWords[1] = usernames[i + 1].ToString();
                }
            }
            foreach (var word in longestTwoWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
