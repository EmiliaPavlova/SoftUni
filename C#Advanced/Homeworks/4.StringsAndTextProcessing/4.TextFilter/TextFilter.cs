using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.TextFilter
{
    class TextFilter
    {
        static void Main(string[] args)
        {
            var bannedWords = Console.ReadLine()
                .Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string text = Console.ReadLine();

            bannedWords.ForEach(x =>
            {
                text = text.Replace(x, new string('*', x.Length));
            });
            Console.WriteLine();
            Console.WriteLine(text);
        }
    }
}
