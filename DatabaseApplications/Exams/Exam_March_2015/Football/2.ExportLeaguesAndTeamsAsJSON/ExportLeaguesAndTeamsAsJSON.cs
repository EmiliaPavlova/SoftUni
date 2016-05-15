namespace _2.ExportLeaguesAndTeamsAsJSON
{
    using System;
    using System.Linq;
    using System.Web.Script.Serialization;
    using _1.FootballEFDataModel;

    class ExportLeaguesAndTeamsAsJSON
    {
        static void Main(string[] args)
        {
            var context = new FootballContext();
            var preJson = context.Leagues
                .OrderBy(l => l.LeagueName)
                .Select(l => new
                {
                    leagueName = l.LeagueName,
                    teams = context.Teams
                    .OrderBy(t => t.TeamName)
                    .Where(t => t.CountryCode == l.CountryCode)
                    .Select(t => t.TeamName)
                })
                .ToList();

            var json = new JavaScriptSerializer().Serialize(preJson);
            //Console.WriteLine(json);
            System.IO.File.WriteAllText("../../leagues-and-teams.json", json);
        }
    }
}
