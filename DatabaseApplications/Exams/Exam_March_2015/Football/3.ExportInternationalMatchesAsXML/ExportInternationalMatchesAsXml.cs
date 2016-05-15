namespace _3.ExportInternationalMatchesAsXML
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Xml.Linq;
    using _1.FootballEFDataModel;

    class ExportInternationalMatchesAsXml
    {
        static void Main(string[] args)
        {
            // Ensure date formatting will use the English names
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var context = new FootballContext();
            var internationalMatches = context.InternationalMatches
                .OrderBy(im => im.MatchDate)
                .ThenBy(im => im.CountryHome.CountryName)
                .ThenBy(im => im.CountryAway.CountryName)
                .Select(im => new
                {
                    CountryCodeHome = im.CountryHome.CountryCode,
                    CountryNameHome = im.CountryHome.CountryName,
                    CountryCodeAway = im.CountryAway.CountryCode,
                    CountryNameAway = im.CountryAway.CountryName,
                    im.HomeGoals,
                    im.AwayGoals,
                    im.MatchDate,
                    im.League.LeagueName
                })
                .ToList();

            var resultXml = new XElement("matches");
            foreach (var match in internationalMatches)
            {
                var matchXml = new XElement("match");
                if (match.MatchDate != null)
                {
                    if (match.MatchDate.Value.TimeOfDay == TimeSpan.Zero)
                    {
                        string date = match.MatchDate.Value.ToString("dd-MMM-yyyy");
                        matchXml.Add(new XAttribute("date", date));
                    }
                    else
                    {
                        string datetime = match.MatchDate.Value.ToString("dd-MMM-yyyy hh:mm");
                        matchXml.Add(new XAttribute("date-time", datetime));
                    }
                }

                matchXml.Add(new XElement("home-country", match.CountryNameHome,
                    new XAttribute("code", match.CountryCodeHome)));
                matchXml.Add(new XElement("away-country", match.CountryNameAway,
                    new XAttribute("code", match.CountryCodeAway)));

                if (match.HomeGoals != null && match.AwayGoals != null)
                {
                    string score = match.HomeGoals.Value + "-" + match.AwayGoals.Value;
                    matchXml.Add(new XElement("score", score));
                }
                if (match.LeagueName != null)
                {
                    matchXml.Add(new XElement("league", match.LeagueName));
                }
                resultXml.Add(matchXml);
            }

            var resultXmlDoc = new XDocument();
            resultXmlDoc.Add(resultXml);
            resultXmlDoc.Save("../../international-matches.xml");

            Console.WriteLine("Matches exported to international-matches.xml");
        }
    }
}
