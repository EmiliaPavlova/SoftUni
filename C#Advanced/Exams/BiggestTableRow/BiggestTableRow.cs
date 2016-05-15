namespace BiggestTableRow
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    class BiggestTableRow
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            Console.ReadLine();

            Regex regex =
                new Regex(@"<tr><td>.*?<\/td><td>(.*?)<\/td><td>(.*?)<\/td><td>(.*?)<\/td><\/tr>");
            string input;
            List<string> prices = new List<string>();
            double sum = double.MinValue;
            bool found = false;

            while ((input = Console.ReadLine()) != "</table>")
            {
                Match match = regex.Match(input);
                double currentSum = 0;
                List<string> currentPrices = new List<string>();
                string store1 = match.Groups[1].Value;
                string store2 = match.Groups[2].Value;
                string store3 = match.Groups[3].Value;

                if (store1 != "-")
                {
                    found = true;
                    currentSum += double.Parse(store1);
                    currentPrices.Add(store1);
                }
                if (store2 != "-")
                {
                    found = true;
                    currentSum += double.Parse(store2);
                    currentPrices.Add(store2);
                }
                if (store3 != "-")
                {
                    found = true;
                    currentSum += double.Parse(store3);
                    currentPrices.Add(store3);
                }
                if (currentSum > sum)
                {
                    sum = currentSum;
                    prices = currentPrices;
                }
            }
            if (!found)
            {
                Console.WriteLine("no data");
            }
            else
            {
                Console.WriteLine("{0} = {1}", sum, string.Join(" + ", prices));
            }
        }
    }
}
