namespace _1.EntityFrameworkMappings
{
    using System;
    using System.Linq;

    class EntityFrameworkMappings
    {
        static void Main(string[] args)
        {
            var context = new PhotographySystemEntities();
            var manufacturerAndModel = context.Cameras
                .Select(c => c.Manufacturer.Name + " " + c.Model)
                .OrderBy(c => c)
                .ToList();
            manufacturerAndModel.ForEach(Console.WriteLine);
        }
    }
}
