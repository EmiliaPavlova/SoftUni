using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CodeFirst.Models
{
    public class Location
    {
        [Required]
        public int Id { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        public string IndividualId { get; set; }

        public virtual Individual Individual { get; set; }

        public DateTime LastSeen { get; set; }
    }
}
