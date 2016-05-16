using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Videos.Rest.Models.BindingModels
{
    public class AddVideoBindingModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public int LocationId { get; set; }
    }
}