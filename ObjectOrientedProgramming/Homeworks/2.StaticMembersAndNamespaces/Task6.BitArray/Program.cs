using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6.BitArray
{
    class Program
    {
        static void Main(string[] args)
        {
            BitArray bitArray = new BitArray(100000);
            bitArray[1] = 1;
            bitArray[99999] = 1;
            Console.WriteLine(bitArray);
        }
    }
}
