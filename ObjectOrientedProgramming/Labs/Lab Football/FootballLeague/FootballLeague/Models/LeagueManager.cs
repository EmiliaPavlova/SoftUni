using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Models
{
    public static class LeagueManager
    {
        public static void HandleInput(string input)
        {
            var inputArgs = input.Split(' ');
            switch (inputArgs[0])
            {
                case "AddTeam":
                    League.AddTeam(new Team(inputArgs[1], inputArgs[2], DateTime.Parse(inputArgs[3])));
                    break;
                case "AddMatch":
                    Team homeTeam = League.GetTeam(inputArgs[2]);
                    Team awayTeam = League.GetTeam(inputArgs[3]);
                    Score score = new Score(int.Parse(inputArgs[4]), int.Parse(inputArgs[5]));
                    Match match = new Match(int.Parse(inputArgs[1]), homeTeam, awayTeam, score);

                    League.AddMatch(match);
                    break;
                case "AddPlayerToTeam":
                    Team teamName = League.GetTeam(inputArgs[5]);
                    Player player = new Player(inputArgs[1], inputArgs[2], 
                        DateTime.Parse(inputArgs[3]), decimal.Parse(inputArgs[4]), teamName);
                    teamName.AddPlayer(player);
                    break;
                case "ListTeams":
                    foreach (Team team in League.Teams)
                    {
                        Console.WriteLine(team.ToString());
                    }
                    break;
                case "ListMatches":
                    foreach (Match matchName in League.Matches)
                    {
                        Console.WriteLine(matchName.ToString());
                    }
                    break;
            }
        }
    }
}
