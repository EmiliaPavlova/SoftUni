namespace SumOfAllValues
{
    using System;
    using System.Text.RegularExpressions;

    class SumOfAllValues
    {
        static void Main(string[] args)
        {
            string keysString = Console.ReadLine();
            var match = Regex.Match(keysString, @"^(?<start>[a-zA-Z_]+)[0-9].*?[0-9](?<end>[a-zA-Z_]+)$");
            string start = match.Groups["start"].Value;
            string end = match.Groups["end"].Value;
            if (start == string.Empty || end == string.Empty)
            {
                Console.WriteLine("<p>A key is missing</p>");
                return;
            }
            string text = Console.ReadLine();
            string numberPattern = String.Format("{0}(.*?){1}", start, end);
            var numbers = Regex.Matches(text, numberPattern);
            double sum = 0;
            foreach (Match digit in numbers)
            {
                double number;
                double.TryParse(digit.Groups[1].Value, out number);
                sum += number;
            }
            Console.WriteLine("<p>The total value is: <em>{0}</em></p>", sum == 0 ? "nothing" : sum.ToString());
        }
    }
}
