using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CriminalActivities.App.Models
{
    using System.ComponentModel.DataAnnotations;
    using CriminalActivities.Models;

    public class AddLocationBindingModel
    {
        [Required]
        public DateTime LastSeen { get; set; }

        [Required]
        public City City { get; set; }
    }
}