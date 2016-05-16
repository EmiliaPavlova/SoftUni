using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pr2.Animals.Animals;

namespace Pr2.Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            var animals = new List<Animal>()
            {
                new Cat("Garfield", 2, Gender.male),
                new Cat("Mussy", 1, Gender.female),
                new Cat("Barry", 5, Gender.male),
                new Dog("Rot", 7, Gender.male),
                new Dog("Sarra", 3, Gender.female),
                new Dog("Jess", 6, Gender.female),
                new Frog("Fred", 1, Gender.male),
                new Frog("Jim", 5, Gender.male),
                new Frog("Sue", 4, Gender.female),
                new Kitten("Rozy", 1),
                new Kitten("Raia", 1),
                new Tomcat("Sam", 1),
                new Tomcat("Neo", 1),
            };

            animals.ForEach(x =>
            {
                StringBuilder output = new StringBuilder();
                output.AppendFormat("{0} {1} says {2}", x.GetType().Name, x.Name, x.ProduceSound());
                Console.WriteLine(output.ToString());
            });

            var catalog = new Dictionary<string, List<double>>();
            animals.ForEach(x =>
            {
                string type = x.GetType().Name;
                if (!catalog.ContainsKey(type))
                {
                    catalog.Add(type, new List<double>());
                    catalog[type].Add(0);
                    catalog[type].Add(0);
                }
                catalog[type][0] += x.Age;
                catalog[type][1] += 1;
            });

            Console.WriteLine();
            foreach (var animal in catalog)
            {
                Console.WriteLine("{0}s average age is {1:#.##} years", animal.Key, animal.Value[0] / animal.Value[1]);
            }
        }
    }
}
