namespace _3.ExportFinishedGamesAsXML
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using _1.EFMappings;

    class ExportFinishedGamesAsXML
    {
        static void Main(string[] args)
        {
            var context = new DiabloContext();
            var finishedGames = context.Games
                .OrderBy(g => g.Name)
                .ThenBy(g => g.Duration)
                .Where(g => g.IsFinished)
                .Select(g => new
                {
                    name = g.Name,
                    duration = g.Duration,
                    username = context.UsersGames
                    .Where(ug => ug.GameId == g.Id)
                    .Select(ug => ug.User.Username),
                    ipAddress = context.UsersGames
                    .Where(ug => ug.GameId == g.Id)
                    .Select(ug => ug.User.IpAddress)
                })
                .ToList();

            var resultXml = new XElement("games");
            foreach (var game in finishedGames)
            {
                var gameXml = new XElement("game");
                if (game.name != null)
                {
                    gameXml.Add(new XAttribute("name", game.name));
                    if (game.duration != null)
                    {
                        string duration = game.duration.Value.ToString();
                        gameXml.Add(new XAttribute("duration", duration));
                    }
                }

                var userXml = new XElement("users");
                var singleUserXml = new XElement("user");
                //foreach (var us in singleUserXml)
                //{
                //    singleUserXml.Add(new XAttribute("username", game.username));
                //    singleUserXml.Add(new XAttribute("ip-address", game.ipAddress));
                //    userXml.Add(singleUserXml);
                //}
                singleUserXml.Add(new XAttribute("username", game.username));
                singleUserXml.Add(new XAttribute("ip-address", game.ipAddress));
                userXml.Add(singleUserXml);

                gameXml.Add(userXml);
                resultXml.Add(gameXml);
            }
            var resultXmlDoc = new XDocument();
            resultXmlDoc.Add(resultXml);
            resultXmlDoc.Save("../../finished-games.xml");
            Console.WriteLine("Finished games exported to finished-games.xml");
        }
    }
}
