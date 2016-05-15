using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.SequencesOfEqualStrings
{
    class SequencesOfEqualStrings
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split();
            Console.Write(input[0]);
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == input[i-1]) 
                {
                    Console.Write(" " + input[i]);
                }
                else 
                {
                    Console.WriteLine();
                    Console.Write(input[i]);
                }
            }
            Console.WriteLine();
        }
    }
}
