using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CriminalActivities.App.Models
{
    using System.ComponentModel.DataAnnotations;
    using CriminalActivities.Models;
    using CriminalActivities.Models.Enums;

    public class AddCriminalBindingModel
    {
        [Required]
        public string Name { get; set; }

        public string Alias { get; set; }
    }
}