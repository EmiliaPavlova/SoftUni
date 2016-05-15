using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.LineNumbers
{
    class LineNumbers
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../Lines.txt"))
            {
                using (StreamWriter writer = new StreamWriter("../../LinesNumbered.txt"))
                {
                    int count = 0;
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        writer.WriteLine("{0}. {1}", count, line);
                        count++;
                        line = reader.ReadLine();
                    }
                }
            }
            Console.WriteLine("The file 'LinesNumbered.txt' is ready in 2.LineNumbers folder.");
        }
    }
}
