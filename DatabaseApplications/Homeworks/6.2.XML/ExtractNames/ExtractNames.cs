namespace ExtractNames
{
    using System;
    using System.Xml;

    class ExtractNames
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../../catalog.xml");

            var rootNode = doc.DocumentElement;
            foreach (XmlNode node in rootNode.ChildNodes)
            {
                var xmlElement = node["name"];
                if (xmlElement != null)
                {
                    Console.WriteLine("Album name: {0}", xmlElement.InnerText);
                }
            }
        }
    }
}
