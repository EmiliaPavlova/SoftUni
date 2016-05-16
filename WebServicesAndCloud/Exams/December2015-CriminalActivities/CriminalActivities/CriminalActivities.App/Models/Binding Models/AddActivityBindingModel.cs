using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CriminalActivities.App.Models
{
    using CriminalActivities.Models;

    public class AddActivityBindingModel
    {
        public string Description { get; set; }

        public ActivityType Type { get; set; }

        public DateTime ActiveFrom { get; set; }

        public DateTime ActiveTo { get; set; }
    }
}