using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Models
{
    public static class League
    {
        private static List<Team> teams = new List<Team>();
        private static List<Match> matches = new List<Match>();

        public static IEnumerable<Team> Teams
        {
            get { return teams; }
        }

        public static IEnumerable<Match> Matches
        {
            get { return matches; }
        }

        public static void AddTeam(Team team)
        {
            if (!TeamIsAdded(team))
            {
                teams.Add(team);
            }
        }

        private static bool TeamIsAdded(Team team)
        {
            return teams.Any(t => t.Name == team.Name);
        }

        public static void AddMatch(Match match)
        {
            if (!MatchIsAdded(match))
            {
                matches.Add(match);
            }
        }

        private static bool MatchIsAdded(Match match)
        {
            return matches.Any(m => m.Id == match.Id);
        }

        public static Team GetTeam(string teamName)
        {
            Team team = teams.FirstOrDefault(t => t.Name == teamName);
            if (team == default(Team))
            {
                throw new ArgumentOutOfRangeException("Team not found");
            }

            return team;
        }
    }
}
