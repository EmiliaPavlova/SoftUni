using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Videos.Rest.Models.BindingModels
{
    public class AddTagBindingModel
    {
        [Required]
        public string Name { get; set; }

        public bool IsAdultContent { get; set; }

        public int VideoId { get; set; }
    }

    public class CreateTagBindingModel
    {
        [Required]
        public int TagId { get; set; }
    }

    public class EditTagBindingModel
    {
        public string Name { get; set; }

        public bool IsAdultContent { get; set; }
    }
}