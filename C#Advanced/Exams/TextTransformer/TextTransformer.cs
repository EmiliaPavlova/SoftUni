namespace TextTransformer
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    class TextTransformer
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            Regex whitespaceRegex = new Regex(@"\s+");
            string input;
            while ((input = Console.ReadLine()) != "burp")
            {
                sb.Append(input);
            }
            string text = whitespaceRegex.Replace(sb.ToString(), " ");
            foreach (Match match in Regex.Matches(text, (@"([$%&'])([^$%&']+)\1")))
            {
                var output = match.Groups[2].Value.ToCharArray();
                for (int i = 0; i < output.Length; i++)
                {
                    if (i % 2 == 0 && output[i] != ' ')
                    {
                        switch (match.Groups[1].Value)
                        {
                            case "$":
                                output[i] += (char)1;
                                break;
                            case "%":
                                output[i] += (char)2;
                                break;
                            case "&":
                                output[i] += (char)3;
                                break;
                            case "'":
                                output[i] += (char)4;
                                break;
                        }
                    }
                    if (i % 2 != 0 && output[i] != ' ')
                    {
                        switch (match.Groups[1].Value)
                        {
                            case "$":
                                output[i] -= (char)1;
                                break;
                            case "%":
                                output[i] -= (char)2;
                                break;
                            case "&":
                                output[i] -= (char)3;
                                break;
                            case "'":
                                output[i] -= (char)4;
                                break;
                        }
                    }
                }

                Console.Write(output);
                Console.Write(" ");
            }
        }
    }
}
