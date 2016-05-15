using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using _01.DatabaseFirst;

namespace _03.UsersAndAlbumsAsXml
{
    class UsersAndAlbumsAsXml
    {
        static void Main(string[] args)
        {
            var context = new PhotographySystemEntities();
            var users = context.Users
                .Where(u => u.Albums.Count > 0)
                .OrderBy(u => u.FullName)
                .Select(u => new
                {
                    u.Id,
                    u.BirthDate,
                    Albums = u.Albums
                        .Select(a => new
                        {
                            a.Name,
                            a.Description,
                            Photograph = a.Photographs
                                .Select(p => p.Title)
                        }),
                    Camera = u.Equipment.Camera.Model,
                    Lens = u.Equipment.Lens.Model,
                    u.Equipment.Camera.Megapixels
                });

            var resultXml = new XElement("users");
            foreach (var user in users)
            {
                var userXml = new XElement("user");
                userXml.Add(new XAttribute("id", user.Id));
                userXml.Add(new XAttribute("birth-date", user.BirthDate));
                var albumXml = new XElement("albums");
                foreach (var album in user.Albums)
                {
                    var albumNode = new XElement("album");
                    albumNode.Add(new XAttribute("name", album.Name));

                    if (album.Description != null)
                    {
                        albumNode.Add(new XAttribute("description", album.Description));
                    }

                    var photographsXml = new XElement("photographs");
                    foreach (var photo in album.Photograph)
                    {
                        var photoNode = new XElement("photograph");
                        photoNode.Add(new XAttribute("title", photo));

                        photographsXml.Add(photoNode);

                    }

                    albumNode.Add(photographsXml);
                    userXml.Add(albumNode);
                }

                var cameraXml = new XElement("camera");
                cameraXml.Add(new XAttribute("model", user.Camera));
                cameraXml.Add(new XAttribute("lens", user.Lens));
                cameraXml.Add(new XAttribute("megapixels", user.Megapixels));

                userXml.Add(cameraXml);
                resultXml.Add(userXml);
            }

            var resultXmlDoc = new XDocument();
            resultXmlDoc.Add(resultXml);
            resultXmlDoc.Save("../../finished-games.xml");

            Console.WriteLine("Users exported to finished-games.xml");
        }
    }
}
