namespace MinesweeperGame
{
    public class Ranking
    {
        public Ranking()
        {
        }

        public Ranking(string name, int points)
        {
            this.Player = name;
            this.Points = points;
        }

        public string Player { get; set; }

        public int Points { get; set; }
    }
}
