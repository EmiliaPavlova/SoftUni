namespace CriminalActivities.Models
{
    using System.Collections.Generic;

    public class ActivityType
    {
        private ICollection<Activity> activities;

        public ActivityType()
        {
            this.activities = new HashSet<Activity>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Activity> Activities
        {
            get { return this.activities; }
            set { this.activities = value; }
        }
    }
}
