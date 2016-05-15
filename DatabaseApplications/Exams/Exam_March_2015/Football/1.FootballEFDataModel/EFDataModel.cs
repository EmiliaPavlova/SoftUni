namespace _1.FootballEFDataModel
{
    using System;
    using System.Linq;
    using System.Runtime.ConstrainedExecution;

    class EFDataModel
    {
        static void Main(string[] args)
        {
            var context = new FootballContext();
            var teams = context.Teams
                .Select(t => t.TeamName)
                .ToList();
            teams.ForEach(Console.WriteLine);
        }
    }
}
