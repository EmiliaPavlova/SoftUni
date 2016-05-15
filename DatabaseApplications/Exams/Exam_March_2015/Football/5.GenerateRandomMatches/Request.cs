namespace _5.GenerateRandomMatches
{
    using System;

    public class Request
    {
        public int GenerateCount { get; set; }

        public int MaxGoals { get; set; }

        public string LeagueName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
