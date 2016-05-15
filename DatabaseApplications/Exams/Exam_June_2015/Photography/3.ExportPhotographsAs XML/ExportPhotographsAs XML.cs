namespace _3.ExportPhotographsAs_XML
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using _1.EntityFrameworkMappings;

    class Program
    {
        static void Main(string[] args)
        {
            var context = new PhotographySystemEntities();
            var allPhotographs = context.Photographs
                .OrderBy(x => x.Title)
                .Select(x => new
                {
                    x.Title,
                    x.Link,
                    Category = x.Category.Name,
                    Equipment = new
                    {
                        Camera = new
                        {
                            Name = x.Equipment.Camera.Manufacturer.Name + " " + x.Equipment.Camera.Model,
                            x.Equipment.Lens.Price,
                            x.Equipment.Camera.Megapixels
                        },
                        Lens = new
                        {
                            x.Equipment.Lens.Price,
                            Name = x.Equipment.Lens.Manufacturer.Name + " " + x.Equipment.Lens.Model
                        }
                    }
                });

            var resultXml = new XElement("photographs");
            foreach (var photograph in allPhotographs)
            {
                var photographXml = new XElement("photograph");
                photographXml.Add(new XAttribute("title", photograph.Title));
                photographXml.Add(new XElement("category", photograph.Category));
                photographXml.Add(new XElement("link", photograph.Link));
                var equipmentXml = new XElement("equipment");
                equipmentXml.Add(new XElement("camera", photograph.Equipment.Camera.Name, new XAttribute("megapixels", photograph.Equipment.Camera.Megapixels)));

                if (photograph.Equipment.Lens.Price.HasValue)
                {
                    equipmentXml.Add(new XElement("lens", photograph.Equipment.Lens.Name,
                        new XAttribute("price", string.Format("{0:f2}", photograph.Equipment.Lens.Price))));
                }
                else
                {
                    equipmentXml.Add(new XElement("lens", photograph.Equipment.Lens.Name));
                }

                photographXml.Add(equipmentXml);
                resultXml.Add(photographXml);
            }
            var resultXmlDoc = new XDocument();
            resultXmlDoc.Add(resultXml);
            resultXmlDoc.Save("../../photographs.xml");
            Console.WriteLine("Photographs exported to photographs.xml");
        }
    }
}
