namespace SemanticHTML
{
    using System;
    using System.Text.RegularExpressions;

    class SemanticHTML
    {
        static void Main(string[] args)
        {
            Regex openTagRegex = new Regex(@"<div.*?\b((?:id|class)\s*=\s*""(\w+)"").*?>");
            Regex closeTagRegex = new Regex(@"<\/div>(\s.*?(\w+)\s*-->)");
            string input;
            
            while ((input = Console.ReadLine()) != "END")
            {
                string output = input;
                Match match = openTagRegex.Match(input);
                if (match.Success)
                {
                    output = input.Replace("div", match.Groups[2].Value);
                    output = output.Replace(match.Groups[1].Value, "");
                    output = Regex.Replace(output, @"\s+>", ">");
                    output = Regex.Replace(output, @"\s+", " ");
                }
                match = closeTagRegex.Match(input);
                if (match.Success)
                {
                    output = output.Replace(match.Groups[1].Value, ""); 
                    output = output.Replace("div", match.Groups[2].Value);
                }
                Console.WriteLine(output);
            }
        }
    }
}
