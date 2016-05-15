using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.PythagoreanNumbers
{
    class PythagoreanNumbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }
        bool hasNumbers = false;
        foreach (int a in numbers) {
            foreach (int b in numbers) {
                foreach (int c in numbers) {
                    if (a <= b && a * a + b * b == c * c) {
                        Console.WriteLine("{0}*{0} + {1}*{1} = {2}*{2}", a, b, c);
                        hasNumbers = true;
                    }
                }
            }
        }
        if (!hasNumbers) {
            Console.WriteLine("No");
        }
        }
    }
}
