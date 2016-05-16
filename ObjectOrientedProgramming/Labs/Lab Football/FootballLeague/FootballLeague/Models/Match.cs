using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Models
{
    public class Match
    {
        private int id;
        private Team homeTeam;
        private Team awayTeam;
        private Score score;

        public Match(int id, Team homeTeam, Team awayTeam, Score score)
        {
            this.Id = id;
            this.HomeTeam = homeTeam;
            this.AwayTeam = awayTeam;
            this.Score = score;
        }

        public int Id { get; set; }

        public Team HomeTeam
        {
            get { return this.homeTeam; }
            set
            {
                if (value == this.homeTeam)
                {
                    throw new ArgumentException("The two teams should be different.");
                }
                this.homeTeam = value;
            }
        }

        public Team AwayTeam
        {
            get { return this.awayTeam; }
            set
            {
                if (value == this.awayTeam)
                {
                    throw new ArgumentException("The two teams should be different.");
                }
                this.awayTeam = value;
            }
        }

        public Score Score { get; set; }

        public Team GetWinner()
        {
            if (this.IsDraw())
            {
                return null;
            }

            return this.Score.HomeTeamGoals > this.Score.AwayTeamGoals ? this.HomeTeam : this.AwayTeam;
        }

        private bool IsDraw()
        {
            return this.Score.AwayTeamGoals == this.Score.HomeTeamGoals;
        }

        public override string ToString()
        {
            string newLine = Environment.NewLine;
            StringBuilder result = new StringBuilder();
            result.Append(string.Format("Home team: {0}{1}Away team: {2}{1}Score: {3}:{4}",
                this.HomeTeam.Name, newLine, this.AwayTeam.Name, this.Score.HomeTeamGoals, this.Score.AwayTeamGoals));

            return result.ToString();
        }
    }
}
