using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CodeFirst.Models
{
    public class Individual
    {
        private ICollection<Location> locations;
        private ICollection<Activity> activities;
        private ICollection<Individual> relatedIndividuals;

        public Individual()
        {
            this.locations = new HashSet<Location>();
            this.activities = new HashSet<Activity>();
            this.relatedIndividuals = new HashSet<Individual>();
        }

        [Required]
        public string Id { get; set; }

        [Required]
        public string FullName { get; set; }

        public string Alias { get; set; }

        public DateTime? BirthDate { get; set; }

        public Status Status { get; set; }

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

        public virtual ICollection<Individual> RelatedIndividuals
        {
            get { return this.relatedIndividuals; }
            set { this.relatedIndividuals = value; }
        }
    }
}
