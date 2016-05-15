using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.NumberCalculations
{
    class NumberCalculations
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Double numbers:");
            var numbers = Console.ReadLine()
                    .Trim()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
            Console.WriteLine("Minimum: " + GetMinimum(numbers));
            Console.WriteLine("Maximum: " + GetMaximum(numbers));
            Console.WriteLine("Average: " + GetAverage(numbers));
            Console.WriteLine("Sum: " + GetSum(numbers));
            Console.WriteLine("Product: " + GetProduct(numbers));

            Console.WriteLine();
            Console.WriteLine("Decimal numbers:");
            var numbersDecimal = Console.ReadLine()
                    .Trim()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(decimal.Parse)
                    .ToArray();
            Console.WriteLine("Minimum: " + GetMinimum(numbersDecimal));
            Console.WriteLine("Maximum: " + GetMaximum(numbersDecimal));
            Console.WriteLine("Average: " + GetAverage(numbersDecimal));
            Console.WriteLine("Sum: " + GetSum(numbersDecimal));
            Console.WriteLine("Product: " + GetProduct(numbersDecimal));
        }

        static double GetMinimum(double[] array)
        {
            double min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }
            return min;
        }

        static decimal GetMinimum(decimal[] array)
        {
            decimal min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }
            return min;
        }

        static double GetMaximum(double[] array)
        {
            double max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            return max;
        }

        static decimal GetMaximum(decimal[] array)
        {
            decimal max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            return max;
        }

        static double GetSum(double[] array)
        {
            double sum = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }

        static decimal GetSum(decimal[] array)
        {
            decimal sum = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }

        static decimal GetAverage(decimal[] array)
        {
            return GetSum(array) / array.Length;
        }

        static double GetAverage(double[] array)
        {
            return GetSum(array) / array.Length;
        }

        static double GetProduct(double[] array)
        {
            double product = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                product *= array[i];
            }
            return product;
        }

        static decimal GetProduct(decimal[] array)
        {
            decimal product = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                product *= array[i];
            }
            return product;
        }
    }
}
