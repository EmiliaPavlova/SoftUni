namespace Generate_Random_Equipments
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Xml.Linq;
    using System.Xml.XPath;

    using Photography_EF_Data_Model;

    class Program
    {
        private const int DefaultGenerateCount = 10;
        private const string DefaultManufacturer = "Nikon";

        static void Main()
        {
            int requestCount = 0;
            var inputXml = XDocument.Load("../../generate-equipments.xml");
            var xElementsGenerateRequests = inputXml.XPathSelectElements("/generate-random-equipments/generate");
            foreach (var xRequest in xElementsGenerateRequests)
            {
                Console.WriteLine("Processing request #{0} ...", ++requestCount);
                var request = ParseRequest(xRequest);
                ProcessRequest(request);
                Console.WriteLine();
            }
        }

        private static EquipmentRequest ParseRequest(XElement xRequest)
        {
            var request = new EquipmentRequest();

            request.GenerateCount = DefaultGenerateCount;
            var xAttributeCount = xRequest.Attribute("generate-count");
            if (xAttributeCount != null)
            {
                request.GenerateCount = int.Parse(xAttributeCount.Value);
            }

            request.Manufacturer = DefaultManufacturer;
            var xElementManufacturer = xRequest.Element("manufacturer");
            if (xElementManufacturer != null)
            {
                request.Manufacturer = xElementManufacturer.Value;
            }

            return request;
        }

        private static void ProcessRequest(EquipmentRequest request)
        {
            var context = new PhotographyContext();
            var manufacturer = context.Manufacturers.FirstOrDefault(x => x.Name == request.Manufacturer);

            var cameraIds = context.Cameras
                .Where(x => x.ManufacturerId == manufacturer.Id)
                .Select(x => x.Id)
                .ToList();
            var lensIds = context.Lenses
                .Where(x => x.ManufacturerId == manufacturer.Id)
                .Select(x => x.Id)
                .ToList();
            var rnd = new Random();
            for (int i = 0; i < request.GenerateCount; i++)
            {
                var equipment = new Equipment();
                var lensRand = rnd.Next(lensIds.Count);
                var cameraRand = rnd.Next(cameraIds.Count);
                equipment.LensId = lensIds[lensRand];
                equipment.CameraId = cameraIds[cameraRand];

                context.Equipments.Add(equipment);
                context.SaveChanges();

                var equipmentDb = context.Equipments
                    .Include(x => x.Camera)
                    .Include(x => x.Lens)
                    .FirstOrDefault(x => x.Id == equipment.Id);

                Console.WriteLine("Equipment added: {0} (Camera: {1} - Lens: {2})", 
                    manufacturer.Name,
                    equipmentDb.Camera.Model,
                    equipmentDb.Lens.Model);
            }
        }
    }
}
