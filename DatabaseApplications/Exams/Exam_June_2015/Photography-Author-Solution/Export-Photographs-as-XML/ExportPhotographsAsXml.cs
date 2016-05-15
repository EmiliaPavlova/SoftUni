namespace Export_Photographs_as_XML
{
    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Xml.Linq;

    using Photography_EF_Data_Model;

    class ExportPhotographsAsXml
    {
        static void Main()
        {
            var context = new PhotographyContext();

            var photographs = context.Photographs
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
                            x.Equipment.Camera.Megapixels
                        },
                        Lens = new
                        {
                            Name = x.Equipment.Lens.Manufacturer.Name + " " + x.Equipment.Lens.Model,
                            x.Equipment.Lens.Price
                        } 
                    },
                });


            var resultXml = new XElement("photographs");
            foreach (var photograph in photographs)
            {
                var photographXml = new XElement("photograph");
                photographXml.Add(new XAttribute("title", photograph.Title));
                photographXml.Add(new XElement("category", photograph.Category));
                photographXml.Add(new XElement("link", photograph.Link));
                var equipmentXml = new XElement("equipment");
                equipmentXml.Add(new XElement("camera", photograph.Equipment.Camera.Name, new XAttribute("megapixels", photograph.Equipment.Camera.Megapixels)));

                if (photograph.Equipment.Lens.Price.HasValue)
                {
                    equipmentXml.Add(new XElement("lens", photograph.Equipment.Lens.Name, new XAttribute("price", string.Format("{0:f2}", photograph.Equipment.Lens.Price))));
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
            resultXmlDoc.Save("photographs.xml");

            Console.WriteLine("Photographs exported to photographs.xml");
        }
    }
}
