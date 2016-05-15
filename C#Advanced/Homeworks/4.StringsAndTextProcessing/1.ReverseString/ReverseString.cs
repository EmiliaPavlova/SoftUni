using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.ReverseString
{
    class ReverseString
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine()
                .ToCharArray();
            string reversed = String.Empty;
            for (int i = input.Length - 1; i >= 0; i--)
            {
                reversed += input[i];
            }
            Console.WriteLine(reversed);
        }
    }
}
