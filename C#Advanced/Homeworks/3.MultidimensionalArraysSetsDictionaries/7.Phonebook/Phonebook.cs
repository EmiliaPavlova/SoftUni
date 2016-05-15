using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Phonebook
{
    class Phonebook
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().Trim();
            Dictionary<string, string> phonebook = new Dictionary<string, string>();

            while (!input.Equals("search"))
            {
                string[] items = input.Split('-');
                if (phonebook.ContainsKey(items[0]))
                    phonebook.Remove(items[0]);
                phonebook.Add(items[0], items[1]);
                input = Console.ReadLine().Trim();
            }
            Console.WriteLine();

            input = Console.ReadLine().Trim();
            while (input.Length > 0)
            {
                if (phonebook.ContainsKey(input))
                {
                    Console.WriteLine("{0} -> {1}", input, phonebook[input]);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Contact {0} does not exist.", input);
                    Console.WriteLine();
                }
                input = Console.ReadLine().Trim();
            }
        }
    }
}
