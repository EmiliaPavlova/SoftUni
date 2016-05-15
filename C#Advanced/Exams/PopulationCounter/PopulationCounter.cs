using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace PopulationCounter
{
    class PopulationCounter
    {
        static void Main(string[] args)
        {
            string input;
            var data = new Dictionary<string, Dictionary<string, long>>();

            while ((input = Console.ReadLine()) != "report")
            {
                string[] tokens = input.Split('|');
                string city = tokens[0].Trim();
                string country = tokens[1].Trim();
                int population = int.Parse(tokens[2]);

                if (!data.ContainsKey(country))
                {
                    data.Add(country, new Dictionary<string, long>());
                }
                if (!data[country].ContainsKey(city))
                {
                    data[country].Add(city, 0);
                }
                data[country][city] = population;
            }

            var hell = data.OrderByDescending(x => x.Value.Sum(a => a.Value));

            foreach (var country in hell)
            {
                Console.Write("{0} (total population: ", country.Key);

                var buffer = new Dictionary<string, BigInteger>();
                BigInteger totalPopulation = 0;

                foreach (var city in country.Value)
                {
                    buffer.Add("=>" + city.Key + ": ", city.Value);
                    totalPopulation += city.Value;
                }

                var items = from pair in buffer
                            orderby pair.Value descending
                            select pair;

                Console.Write(totalPopulation + ")");
                Console.WriteLine();
                foreach (var smth in items)
                {
                    Console.WriteLine("{0}{1}", smth.Key, smth.Value);
                }
            }
        }
    }
}
