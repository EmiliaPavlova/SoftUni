using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _7.LettersChangeNumbers
{
    internal class LettersChangeNumbers
    {
        private static void Main(string[] args)
        {
            var input = Regex.Split(Console.ReadLine(), @"\s+");
            double temp = 0;
            double sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != "")
                {
                    double number = double.Parse(input[i].Substring(1, input[i].Length - 2));
                    temp = firstAction(number, input[i][0]);
                    temp = lastAction(temp, input[i][input[i].Length - 1]);
                    sum += temp;
                }
            }
            Console.WriteLine("{0:f}", sum);
        }

        public static double firstAction(double num, char letter)
        {
            double value = 0;
            double action = 0;
            if (letter >= 'A' && letter <= 'Z')
            {
                value = letter - 64;
                action = num / value;
            }
            if (letter >= 'a' && letter <= 'z')
            {
                value = letter - 96;
                action = num * value;
            }
            return action;
        }

        public static double lastAction(double num, char letter)
        {
            double value = 0;
            double action = 0;
            if (letter >= 'A' && letter <= 'Z')
            {
                value = letter - 64;
                action = num - value;
            }
            if (letter >= 'a' && letter <= 'z')
            {
                value = letter - 96;
                action = num + value;
            }
            return action;
        }
    }
}
