using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _3.WordCount
{
    class WordCount
    {
        static void Main(string[] args)
        {
            using (StreamReader wordsReader = new StreamReader("../../words.txt"))
            {
                using (StreamReader textReader = new StreamReader("../../text.txt")) 
                {
                    using (StreamWriter writer = new StreamWriter("../../results.txt"))
                    {
                        var words = new List<string>();
                        var word = wordsReader.ReadLine();
                        while (word != null)
                        {
                            words.Add(word);
                            word = wordsReader.ReadLine();
                        }
                        var text = textReader.ReadToEnd().ToLower();

                        var result = new SortedDictionary<int, string>();
                        words.ForEach(x =>
                        {
                            var pattern = @"\b" + x.ToLower() + @"\b";
                            var match = Regex.Matches(text, pattern);
                            result.Add(match.Count, x);
                        });

                        foreach (var foundWord in result.Reverse())
                        {
                            writer.WriteLine("{0} - {1}", foundWord.Value, foundWord.Key);
                        }
                    }
                }
            }
            Console.WriteLine("The file 'results.txt' is ready in 3.WordCount folder.");
        }
    }
}
