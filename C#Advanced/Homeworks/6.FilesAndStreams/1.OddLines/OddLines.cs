using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.OddLines
{
    class OddLines
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../Lines.txt"))
            {
                int count = 0;
                var line = reader.ReadLine();
                while (line != null)
                {
                    if (count % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }
                    count++;
                    line = reader.ReadLine();
                }
            }
        }
    }
}
