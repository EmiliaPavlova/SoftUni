namespace VladkosNotebook
{
    using System;
    using System.Collections.Generic;

    class VladkosNotebook
    {
        static void Main(string[] args)
        {
            var colorSheets = new SortedDictionary<string, Dictionary<String, List<string>>>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var tokens = input.Split('|');
                var color = tokens[0];
                if (!colorSheets.ContainsKey(color))
                {
                    colorSheets.Add(color, new Dictionary<string, List<string>>());
                }
                switch (tokens[1])
                {
                    case "age":
                        if (!colorSheets[color].ContainsKey("age"))
                        {
                            colorSheets[color]["age"] = new List<string>{tokens[2]};
                        }
                        break;
                    case "name":
                        if (!colorSheets[color].ContainsKey("name"))
                        {
                            colorSheets[color]["name"] = new List<string> { tokens[2] };
                        }
                        break;
                    case "win":
                        if (!colorSheets[color].ContainsKey("wins"))
                        {
                            colorSheets[color]["wins"] = new List<string>();
                        }
                        if (!colorSheets[color].ContainsKey("opponents"))
                        {
                            colorSheets[color]["opponents"] = new List<string>();
                        }
                        colorSheets[color]["wins"].Add("x");
                        colorSheets[color]["opponents"].Add(tokens[2]);
                        break;
                    case "loss":
                        if (!colorSheets[color].ContainsKey("losses"))
                        {
                            colorSheets[color]["losses"] = new List<string>();
                        }
                        if (!colorSheets[color].ContainsKey("opponents"))
                        {
                            colorSheets[color]["opponents"] = new List<string>();
                        }
                        colorSheets[color]["losses"].Add("x");
                        colorSheets[color]["opponents"].Add(tokens[2]);
                        break;
                }
            }
            var found = false;
            foreach (var key in colorSheets.Keys)
            {
                if (!colorSheets[key].ContainsKey("name") || !colorSheets[key].ContainsKey("age"))
                {
                    continue;
                }
                found = true;
                if (!colorSheets[key].ContainsKey("opponents"))
                {
                    Console.WriteLine("Color: " + key);
                    Console.WriteLine("-age: " + colorSheets[key]["age"][0]);
                    Console.WriteLine("-name: " + colorSheets[key]["name"][0]);
                    Console.WriteLine("-opponents: (empty)");
                    Console.WriteLine("-rank: 1.00");
                }
                else if (colorSheets[key].ContainsKey("opponents"))
                {
                    var losses = colorSheets[key].ContainsKey("losses") ? colorSheets[key]["losses"].Count + 1.0 : 1.0;
                    var wins = colorSheets[key].ContainsKey("wins") ? colorSheets[key]["wins"].Count + 1.0 : 1.0;
                    var rank = wins / losses;
                    colorSheets[key]["opponents"].Sort(StringComparer.Ordinal);

                    Console.WriteLine("Color: " + key);
                    Console.WriteLine("-age: " + colorSheets[key]["age"][0]);
                    Console.WriteLine("-name: " + colorSheets[key]["name"][0]);
                    Console.WriteLine("-opponents: " + string.Join(", ", colorSheets[key]["opponents"]));
                    Console.WriteLine("-rank: {0:F2}", rank);
                }
            }
            if (!found)
            {
                Console.WriteLine("No data recovered.");
            }
        }
    }
}
