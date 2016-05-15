using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.CategorizeNumbers
{
    class CategorizeNumbers
    {
        static void Main(string[] args)
        {
            var integers = new List<double>();
            var doubles = new List<double>();
            Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToList()
                .ForEach(number =>
                {
                    if (number % 1 == 0)
                    {
                        integers.Add((int) number);
                    }
                    else
                    {
                        doubles.Add(number);
                    }
                });
            Console.WriteLine("[{0}] -> min: {1}, max: {2}, sum: {3}, avg: {4:F2}", String.Join(" ", doubles), doubles.Min(), doubles.Max(), doubles.Sum(), doubles.Average());
            Console.WriteLine("[{0}] -> min: {1}, max: {2}, sum: {3}, avg: {4:F2}", String.Join(" ", integers), integers.Min(), integers.Max(), integers.Sum(), String.Format("{0:F2}", integers.Average()));
            }
    }
}
