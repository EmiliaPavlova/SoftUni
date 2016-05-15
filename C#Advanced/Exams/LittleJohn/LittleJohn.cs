namespace LittleJohn
{
    using System;
    using System.Text.RegularExpressions;

    class LittleJohn
    {
        static void Main(string[] args)
        {
            Regex arrow = new Regex(@"(>{1,3})-{5}(>{1,2})");
            int small = 0;
            int medium = 0;
            int large = 0;
            for (int i = 0; i < 4; i++)
            {
                MatchCollection matches = arrow.Matches(Console.ReadLine());
                foreach (Match match in matches)
                {
                    if (match.Groups[1].Value.Length == 3 && match.Groups[2].Value.Length >= 2)
                    {
                        large++;
                    }
                    if (match.Groups[1].Value.Length >= 2 && match.Groups[2].Value.Length == 1 ||
                        match.Groups[1].Value.Length == 2 && match.Groups[2].Value.Length >= 1)
                    {
                        medium++;
                    }
                    if (match.Groups[1].Value.Length == 1 && match.Groups[2].Value.Length >= 1)
                    {
                        small++;
                    }
                }
            }
            int concatenated = int.Parse("" + small + medium + large);
            string binary = Convert.ToString(concatenated, 2);
            string reversedBinary = Reverse(binary);
            string concatenatedBinary = binary + reversedBinary;
            string result = Convert.ToInt32(concatenatedBinary, 2).ToString();
            Console.WriteLine(result);
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
