namespace CriminalActivities.Models
{
    using System;

    public class Location
    {
        public int Id { get; set; }

        public DateTime LastSeen { get; set; }

        public int? CriminalId { get; set; }

        public virtual Criminal Criminal { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }
    }
}
