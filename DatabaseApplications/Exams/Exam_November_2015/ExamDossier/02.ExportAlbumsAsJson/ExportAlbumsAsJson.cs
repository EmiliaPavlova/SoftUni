using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using _01.DatabaseFirst;

namespace _02.ExportAlbumsAsJson
{
    class ExportAlbumsAsJson
    {
        static void Main(string[] args)
        {
            var context = new PhotographySystemEntities();
            var albums = context.Albums
                .Where(a => a.Photographs.Count != 0)
                .OrderBy(a => a.Photographs.Count)
                .ThenBy(a => a.Id)
                .Select(a => new
                {
                    id = a.Id,
                    name = a.Name,
                    owner = a.User.FullName,
                    photoCount = a.Photographs.Count
                });

            var jsSerializer = new JavaScriptSerializer();
            var json = jsSerializer.Serialize(albums);
            File.WriteAllText("../../albums.json", json);
            Console.WriteLine("File albums.json exported.");
        }
    }
}
