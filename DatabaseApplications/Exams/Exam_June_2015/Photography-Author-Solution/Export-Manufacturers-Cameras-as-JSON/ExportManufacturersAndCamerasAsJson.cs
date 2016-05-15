namespace Export_Manufacturers_Cameras_as_JSON
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;

    using Photography_EF_Data_Model;

    class ExportManufacturersAndCamerasAsJson
    {
        static void Main()
        {
            var context = new PhotographyContext();
            var manufacturersWithTeams = context.Manufacturers
                .OrderBy(x => x.Name)
                .Select(x => new
                {
                    manufacturer = x.Name,
                    cameras = x.Cameras
                        .OrderBy(c => c.Model)
                        .Select(c => new
                        {
                            model = c.Model,
                            price = c.Price
                        })
                });
            var jsSerializer = new JavaScriptSerializer();
            var json = jsSerializer.Serialize(manufacturersWithTeams);
            File.WriteAllText("manufacturers-and-cameras.json", json);
            Console.WriteLine("File manufacturers-and-cameras.json exported.");
        }
    }
}
