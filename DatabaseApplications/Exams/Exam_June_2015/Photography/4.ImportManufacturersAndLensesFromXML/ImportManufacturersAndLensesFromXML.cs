namespace _4.ImportManufacturersAndLensesFromXML
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;
    using _1.EntityFrameworkMappings;

    class ImportManufacturersAndLensesFromXML
    {
        static void Main()
        {
            var inputXml = XDocument.Load("../../manufacturers-and-lenses.xml");
            var xManufacturers = inputXml.XPathSelectElements("/manufacturers-and-lenses/manufacturer");
            var context = new PhotographySystemEntities();
            var manufacturersCount = 0;
            foreach (var xManufacturer in xManufacturers)
            {
                Console.WriteLine("Processing manufacturer #{0} ...", ++manufacturersCount);
                Manufacturer manufacturer = CreateManufacturerIfNotExists(context, xManufacturer);
                var xLenses = xManufacturer.XPathSelectElements("lenses/lens");
                CreateLensesIfNotExist(context, xLenses, manufacturer);
                Console.WriteLine();
            }
        }

        private static Manufacturer CreateManufacturerIfNotExists(PhotographySystemEntities context, XElement xManufacturer)
        {
            Manufacturer manufacturer = null;
            var xElementManufacturerName = xManufacturer.Element("manufacturer-name");
            if (xElementManufacturerName != null)
            {
                var manufacturerName = xElementManufacturerName.Value;
                manufacturer = context.Manufacturers.FirstOrDefault(x => x.Name == manufacturerName);
                if (manufacturer != null)
                {
                    Console.WriteLine("Existing manufacturer: {0}", manufacturerName);
                }
                else
                {
                    manufacturer = new Manufacturer
                    {
                        Name = manufacturerName,
                    };
                    context.Manufacturers.Add(manufacturer);
                    context.SaveChanges();
                    Console.WriteLine("Created manufacturer: {0}", manufacturerName);
                }
            }

            return manufacturer;
        }

        private static void CreateLensesIfNotExist(PhotographySystemEntities context, IEnumerable<XElement> xLenses, Manufacturer manufacturer)
        {
            foreach (var xLens in xLenses)
            {
                var lensModel = xLens.Attribute("model").Value;
                var lensType = xLens.Attribute("type").Value;
                var lensPrice = xLens.Attribute("price");

                var lens = context.Lenses.FirstOrDefault(x => x.Model == lensModel);
                if (lens != null)
                {
                    Console.WriteLine("Existing lens: {0}", lensModel);
                }
                else
                {
                    lens = new Lens
                    {
                        Model = lensModel,
                        Type = lensType,
                        Price = lensPrice != null ? decimal.Parse(lensPrice.Value) : default(decimal?),
                        ManufacturerId = manufacturer.Id
                    };

                    context.Lenses.Add(lens);
                    context.SaveChanges();
                    Console.WriteLine("Created lens: {0}", lensModel);
                }
            }
        }
    }
}
