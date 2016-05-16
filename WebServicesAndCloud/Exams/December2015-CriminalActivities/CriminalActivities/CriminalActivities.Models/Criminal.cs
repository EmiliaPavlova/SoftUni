namespace CriminalActivities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Enums;

    public class Criminal
    {
        private ICollection<Location> locations;
        private ICollection<Activity> activities;

        public Criminal()
        {
            this.locations = new HashSet<Location>();
            this.activities = new HashSet<Activity>();
        }

        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        public string Alias { get; set; }

        public DateTime? BirthDate { get; set; }

        public Status Status { get; set; }

        public string CreatorId { get; set; }

        public virtual User Creator { get; set; }

        public int? CartelId { get; set; }

        public virtual Cartel Cartel { get; set; }

        public virtual ICollection<Location> Locations
        {
            get { return this.locations; }
            set { this.locations = value; }
        }

        public virtual ICollection<Activity> Activities
        {
            get { return this.activities; }
            set { this.activities = value; }
        }
    }
}
