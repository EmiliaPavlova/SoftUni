namespace _2.ExportManufacturersAndCamerasAsJSON
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;
    using _1.EntityFrameworkMappings;

    class ExportManufacturersAndCamerasAsJSON
    {
        static void Main(string[] args)
        {
            var context = new PhotographySystemEntities();
            var preJson = context.Manufacturers
                .OrderBy(m => m.Name)
                .Select(m => new
                {
                    manufacturer = m.Name,
                    cameras = context.Cameras
                    .OrderBy(c => c.Model)
                    .Where(c => c.ManufacturerId == m.Id)
                    .Select(c => new
                    {
                        model = c.Model,
                        price = c.Price
                    })
                })
                .ToList();

            var json = new JavaScriptSerializer().Serialize(preJson);
            //Console.WriteLine(json);
            System.IO.File.WriteAllText("../../manufactureres-and-cameras.json", json);
        }
    }
}
