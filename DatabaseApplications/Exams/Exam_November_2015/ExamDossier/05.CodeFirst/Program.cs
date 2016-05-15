using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new DossierContext();
            var individuals = context.Individuals.Count();
        }
    }
}
