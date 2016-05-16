namespace CriminalActivities.Models
{
    using System.Collections.Generic;

    public class Cartel
    {
        private ICollection<Criminal> members;

        public Cartel()
        {
            this.members = new HashSet<Criminal>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Criminal> Members
        {
            get { return this.members; }
            set { this.members = value; }
        }
    }
}
