namespace _1.EFMappings
{
    using System;
    using System.Linq;

    class EFMappings
    {
        static void Main(string[] args)
        {
            var context = new DiabloContext();
            var characters = context.Characters
                .Select(c => c.Name)
                .ToList();
            characters.ForEach(Console.WriteLine);
        }
    }
}
