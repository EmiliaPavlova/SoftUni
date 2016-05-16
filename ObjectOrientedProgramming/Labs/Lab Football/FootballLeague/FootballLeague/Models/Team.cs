using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Models
{
    public class Team
    {
        private string name;
        private string nickname;
        private DateTime dateOfFounding;
        private List<Player> players;

        public Team(string name, string nickname, DateTime dateOfFounding)
        {
            this.Name = name;
            this.Nickname = nickname;
            this.DateOfFounding = dateOfFounding;
            this.players = new List<Player>();
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException("Name should be at least 5 characters long");
                }
                this.name = value;
            }
        }

        public string Nickname
        {
            get { return this.nickname; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException("Nickname should be at least 5 characters long");
                }
                this.nickname = value;
            }
        }

        public DateTime DateOfFounding
        {
            get { return this.dateOfFounding; }
            set
            {
                if (value.Year < 1850)
                {
                    throw new ArgumentException("Date of birth cannot be earlier than 1850");
                }
            }
        }

        public IEnumerable<Player> Players
        {
            get { return this.players; }
        }

        public void AddPlayer(Player player)
        {
            if (CheckIfPlayerExist(player))
            {
                throw new InvalidOperationException("Player already exist for that team");
            }
            this.players.Add(player);
        }

        private bool CheckIfPlayerExist(Player player)
        {
            return this.players.Any(p => p.FirstName == player.FirstName &&
                                         p.LastName == player.LastName);
        }

        public override string ToString()
        {
            string newLine = Environment.NewLine;
            StringBuilder result = new StringBuilder();
            result.Append(string.Format("Team: {0}{1}Nickname: {2}{1}Date of Founding : {3}",
                this.Name, newLine, this.Nickname, this.DateOfFounding));

            return result.ToString();
        }
    }
}
