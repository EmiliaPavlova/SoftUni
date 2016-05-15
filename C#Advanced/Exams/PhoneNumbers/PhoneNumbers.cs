namespace PhoneNumbers
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    class PhoneNumbers
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                sb.Append(input);
            }
            Regex regex = new Regex(@"(?<name>[A-Z][a-zA-Z]*)[^a-zA-Z+]*?(?<phone>\+?[0-9][0-9.() \-\/]*[0-9])");
            MatchCollection matches = regex.Matches(sb.ToString());
            if (matches.Count == 0)
            {
                Console.WriteLine("<p>No matches!</p>");
                return;
            }
            Console.Write("<ol>");
            foreach (Match match in matches)
            {
                string phone = Regex.Replace(match.Groups["phone"].Value, @"[^+0-9]+", string.Empty);
                Console.Write("<li><b>{0}:</b> {1}</li>", match.Groups["name"], phone);
            }
            Console.Write("</ol>");
        }
    }
}
