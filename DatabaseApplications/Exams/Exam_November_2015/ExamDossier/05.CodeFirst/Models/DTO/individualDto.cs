using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CodeFirst.Models.DTO
{
    public class IndividualDto
    {
        public string FullName { get; set; }

        public string Alias { get; set; }

        public DateTime? BirthDate { get; set; }

        public Status Status { get; set; }

        public virtual ActivityType ActivityType { get; set; }

        public string IndividualId { get; set; }

        public DateTime ActiveFrom { get; set; }

        public DateTime ActiveTo { get; set; }
    }
}
