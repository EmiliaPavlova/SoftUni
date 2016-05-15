namespace OlympicsAreComing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class OlympicsAreComing
    {
        static void Main(string[] args)
        {
            string input;
            Regex regex = new Regex(@"\s*\|\s*");
            Regex whitespaceRegex = new Regex(@"\s+");
            var data = new Dictionary<string, List<string>>();
            while ((input = Console.ReadLine()) != "report")
            {
                string[] tokens = regex.Split(input.Trim());
                string name = whitespaceRegex.Replace(tokens[0].Trim(), " ");
                string country = whitespaceRegex.Replace(tokens[1].Trim(), " ");
                if (!data.ContainsKey(country))
                {
                    data.Add(country, new List<string>());
                }
                data[country].Add(name);

            }
            var ordered = data.OrderByDescending(x => x.Value.Count);

            foreach (var country in ordered)
            {
                Console.WriteLine("{0} ({1} participants): {2} wins", country.Key, country.Value.Distinct().Count(), country.Value.Count);
            }
        }
    }
}
