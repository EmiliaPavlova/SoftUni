using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _9.TerroristsWin
{
    internal class TerroristsWin
    {
        private static void Main(string[] args)
        {
            String input = Console.ReadLine();
            String pat = @"\|(.*?)\|";
            var match = Regex.Match(input, pat);
            while (match.Success)
            {
                string bomb = match.Groups[1].ToString();
                int bombSize = 0;
                for (int i = 0; i < bomb.Length; i++)
                {
                    bombSize += bomb[i];
                }
                bombSize %= 10;
                String bombAreaPath = @".{0," + bombSize + @"}\|" + bomb + @"\|.{0," + bombSize + @"}";
                string matchedArea = Regex.Match(input, bombAreaPath).Value;
                input = input.Replace(matchedArea, new string('.', matchedArea.Length));
                //input = Regex.Replace(input, bombAreaPath, new string('.', (bombSize * 2 + 2 + bomb.Length)));
                match = Regex.Match(input, pat);
            }
            Console.WriteLine(input);
        }
    }
}