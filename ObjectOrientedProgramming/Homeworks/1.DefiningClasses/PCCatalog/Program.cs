using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCCatalog
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Component> parts = new List<Component>()
            {
                new Component("CPU", 123.4M, "good"),
                new Component("RAM", 23.4M, "bad"),
                new Component("Screen", 13.4M),
                new Component("CD", 12.4M, "nice"),
                new Component("Motherboard", 1213.4M)
            };

            Computer myComputer = new Computer("PC 1", parts);
            Computer newComputer = new Computer("PC 2");
            Computer newComp = new Computer("PC 3", new List<Component>()
            {
                new Component("CPU", 400.9M, "good"),
                new Component("RAM", 80M, "bad"),
            });

            myComputer.GetName();
            myComputer.GetComponents();
            myComputer.GetPrice();
            Console.WriteLine();

            newComputer.GetName();
            newComputer.GetComponents();
            newComputer.GetPrice();
            Console.WriteLine();

            List<Computer> computers = new List<Computer>() { myComputer, newComputer, newComp };
            computers.Sort((x, y) => (int)(x.Price - y.Price));
            computers.ForEach(Console.WriteLine);
        }
    }
}
