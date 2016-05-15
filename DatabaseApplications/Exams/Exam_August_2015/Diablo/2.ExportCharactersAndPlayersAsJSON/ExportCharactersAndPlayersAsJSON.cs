namespace _2.ExportCharactersAndPlayersAsJSON
{
    using System;
    using System.Linq;
    using System.Web.Script.Serialization;
    using _1.EFMappings;

    class ExportCharactersAndPlayersAsJSON
    {
        static void Main(string[] args)
        {
            var context = new DiabloContext();
            var preJson = context.Characters
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    name = c.Name,
                    playedBy = context.UsersGames
                    .Where(ug => ug.CharacterId == c.Id)
                    .Select(ug => ug.User.Username)
                })
                .ToList();

            var json = new JavaScriptSerializer().Serialize(preJson);
            //Console.WriteLine(json);
            System.IO.File.WriteAllText("../../characters.json", json);
        }
    }
}
