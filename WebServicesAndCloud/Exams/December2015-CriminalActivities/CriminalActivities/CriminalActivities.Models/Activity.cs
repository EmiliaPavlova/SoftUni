namespace CriminalActivities.Models
{
    using System;

    public class Activity
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime ActiveFrom { get; set; }

        public DateTime? ActiveTo { get; set; }

        public int? CriminalId { get; set; }

        public virtual Criminal Criminal { get; set; }

        public int ActivityTypeId { get; set; }

        public virtual ActivityType ActivityType { get; set; }
    }
}
