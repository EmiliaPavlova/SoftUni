using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using _01.DatabaseFirst;

namespace _04.ImportManufacturersFromXml
{
    class ImportManufacturersFromXml
    {
        static void Main(string[] args)
        {
            var inputXml = XDocument.Load("../../manufacturers-and-goods.xml");
            var xManufacturers = inputXml.XPathSelectElements("/manufacturers/manufacturer");
            var context = new PhotographySystemEntities();
            foreach (var manufacturer in xManufacturers)
            {
                try
                {
                    ImportManufacturers(manufacturer, context);
                }
                catch (Exception ex)
                {
                    if (ex is ValidationException || ex is InvalidOperationException || ex is DataException)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }

        private static void ImportManufacturers(XElement manufacturer, PhotographySystemEntities context)
        {
            var manufacturerName = manufacturer.Attribute("name").Value;

            if (GetManufacturerByName(manufacturerName, context) != null)
            {
                throw new InvalidOperationException(string.Format(
                    "Manufacturer {0} already exists.", manufacturerName));
            }

            var manufacturerWTF = new Manufacturer()
            {
                Name = manufacturerName
            };

            var cameras = manufacturer.XPathSelectElements("cameras/camera");
            foreach (var camera in cameras)
            {
                ImportCamera(context, camera, manufacturerName);
            }

            var lenses = manufacturer.XPathSelectElements("lenses/lens");
            foreach (var lense in lenses)
            {
                ImportLense(context, lense, manufacturerName);
            }

            context.Manufacturers.Add(manufacturerWTF);
            context.SaveChanges();
        }

        private static void ImportLense(PhotographySystemEntities context, XElement lense, string manufacturerName)
        {
            var lenseNode = lense.XPathSelectElement("lens");
            var lenseModel = lenseNode.Attribute("model").Value;
            var lenseType = lenseNode.Attribute("type").Value;

            var lens = new Lens()
            {
                Model = lenseModel,
                Type = lenseType
            };

            var lensePrice = lenseNode.Attribute("price");
            if (lensePrice != null)
            {
                lens.Price = decimal.Parse(lensePrice.Value);
            }
        }

        private static void ImportCamera(PhotographySystemEntities context, XElement camera, string manufacturerName)
        {
            var cameraNode = camera.XPathSelectElement("camera");
            var cameraModel = cameraNode.Attribute("model").Value;
            var cameraYear = int.Parse(cameraNode.Attribute("year").Value);

            var cam = new Camera()
            {
                Model = cameraModel,
                Year = cameraYear
            };

            var cameraPrice = cameraNode.Attribute("price");
            if (cameraPrice != null)
            {
                cam.Price = decimal.Parse(cameraPrice.Value);
            }

            var cameraMegapixels = cameraNode.Attribute("megapixels");
            if (cameraMegapixels != null)
            {
                cam.Megapixels = int.Parse(cameraMegapixels.Value);
            }
        }

        private static Manufacturer GetManufacturerByName(string manufacturerName, PhotographySystemEntities context)
        {
            return context.Manufacturers.FirstOrDefault(m => m.Name == manufacturerName);
        }
    }
}
