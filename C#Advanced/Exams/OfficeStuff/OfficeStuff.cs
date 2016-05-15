namespace OfficeStuff
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    class OfficeStuff
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            var data = new SortedDictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < rows; i++)
            {
                foreach (Match match in Regex.Matches(Console.ReadLine(), @"\|(\w+)\s*?-\s*?(\d+)\s*?-\s*?(\w+)\|"))
                {
                    string company = match.Groups[1].Value;
                    string product = match.Groups[3].Value;
                    int amount = int.Parse(match.Groups[2].Value);

                    if (!data.ContainsKey(company))
                    {
                        data.Add(company, new Dictionary<string, int>());
                    }
                    if (!data[company].ContainsKey(product))
                    {
                        data[company].Add(product, 0);
                    }
                    data[company][product] += amount;
                }
            }
            foreach (var company in data)
            {
                Console.Write("{0}: ", company.Key);
                var buffer = new List<string>();
                foreach (var product in company.Value)
                {
                    buffer.Add(product.Key + "-" + product.Value);
                }
                Console.WriteLine(string.Join(", ", buffer));
            }
        }
    }
}
