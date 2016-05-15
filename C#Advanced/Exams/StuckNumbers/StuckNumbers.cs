using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuckNumbers
{
    class StuckNumbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            bool hasMatch = false;
            for (int i1 = 0; i1 < numbers.Length; i1++)
            {
                for (int i2 = 0; i2 < numbers.Length; i2++)
                {
                    for (int i3 = 0; i3 < numbers.Length; i3++)
                    {
                        for (int i4 = 0; i4 < numbers.Length; i4++)
                        {
                            String a = numbers[i1];
                            String b = numbers[i2];
                            String c = numbers[i3];
                            String d = numbers[i4];

                            if (a != b && a != c && a != d && b != c && b != d && c != d)
                            {
                                String left = a + b;
                                String right = c + d;
                                //StringBuilder left = new StringBuilder(a);
                                //left.Append(b);
                                //StringBuilder right = new StringBuilder(c);
                                //right.Append(d);
                                if (left.Equals(right))
                                {
                                    Console.WriteLine("{0}|{1}=={2}|{3}", a, b, c, d);
                                    hasMatch = true;
                                }
                            }
                        }
                    }
                }
            }
            if (!hasMatch)
            {
                Console.WriteLine("No");
            }
        }
    }
}
