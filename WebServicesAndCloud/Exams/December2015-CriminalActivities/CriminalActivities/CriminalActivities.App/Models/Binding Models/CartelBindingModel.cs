using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CriminalActivities.App.Models.Binding_Models
{
    using System.ComponentModel.DataAnnotations;
    using CriminalActivities.Models;

    public class CartelBindingModel
    {
        [Required]
        public string Name { get; set; }

        public IEnumerable<int> CriminalIds { get; set; }
    }
}