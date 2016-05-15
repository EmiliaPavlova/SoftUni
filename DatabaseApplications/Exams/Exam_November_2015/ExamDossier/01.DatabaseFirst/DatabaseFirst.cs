using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DatabaseFirst
{
    class DatabaseFirst
    {
        static void Main(string[] args)
        {
            var context = new PhotographySystemEntities();
            var photographs = context.Photographs
                .Select(p => p.Title + " -- " + p.Link);
            Console.WriteLine(string.Join("\n", photographs));
        }
    }
}
