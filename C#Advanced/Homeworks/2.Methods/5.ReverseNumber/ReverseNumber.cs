using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.ReverseNumber
{
    class ReverseNumber
    {
        static void Main(string[] args)
        {
            var number = double.Parse(Console.ReadLine());

            Console.WriteLine(GetReversedNumber(number));
        }

        static double GetReversedNumber(double number)
        {
            string numString = number.ToString();
            numString = string.Join("", numString.Reverse());

            return double.Parse(numString);
        }
    }
}
