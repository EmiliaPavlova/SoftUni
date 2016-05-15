using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CodeFirst.Models
{
    public class Activity
    {
        [Required]
        public int Id { get; set; }

        public string Description { get; set; }

        public int ActivityTypeId { get; set; }

        public virtual ActivityType ActivityType { get; set; }

        public string IndividualId { get; set; }

        public DateTime ActiveFrom { get; set; }

        public DateTime ActiveTo { get; set; }

    }
}
