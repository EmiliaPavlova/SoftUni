namespace DeleteAlbums
{
    using System;
    using System.Xml.Linq;

    class DeleteAlbums
    {
        static void Main(string[] args)
        {
            var doc = XDocument.Load("../../../../catalog.xml");
            var result = new XDocument();
            var root = new XElement("category");
            result.Add(root);

            var catalog = doc.Root.Elements();
            foreach (XElement album in catalog)
            {
                var price = album.Element("price");
                if (price != null)
                {
                    if (double.Parse(price.Value) < 20)
                    {
                        root.Add(album);
                    }
                }
            }

            Console.WriteLine("Saved!");
            result.Save(@"..\..\..\..\cheap-albums-catalog.xml");
        }
    }
}
