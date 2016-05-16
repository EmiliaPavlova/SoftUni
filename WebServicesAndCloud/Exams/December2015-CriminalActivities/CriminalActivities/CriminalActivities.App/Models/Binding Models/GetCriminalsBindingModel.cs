using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CriminalActivities.App.Models
{
    using System.ComponentModel.DataAnnotations;

    public class GetCriminalsBindingModel
    {
        [Required]
        public string Name { get; set; }

        public string Alias { get; set; }
    }
}