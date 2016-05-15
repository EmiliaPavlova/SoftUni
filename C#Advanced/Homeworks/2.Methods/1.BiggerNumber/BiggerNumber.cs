using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.BiggerNumber
{
    class BiggerNumber
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int max = GetMax(number1, number2);
            Console.WriteLine(max);
        }

        static int GetMax(int num1, int num2)
        {
            int max = int.MinValue;
            if (num1 >= num2)
            {
                max = num1;
            }
            else
            {
                max = num2;
            }
            return max;
        }
    }
}
