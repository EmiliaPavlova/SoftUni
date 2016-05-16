using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CriminalActivities.App.Models
{
    using System.Linq.Expressions;
    using CriminalActivities.Models;

    public class ActivityViewModel
    {
        public string Description { get; set; }

        public DateTime ActiveFrom { get; set; }

        public DateTime ActiveTo { get; set; }

        public string Type { get; set; }

        public string Criminal { get; set; }

        public static Expression<Func<Activity, ActivityViewModel>> Create
        {
            get
            {
                return a => new ActivityViewModel()
                {
                    Description = a.Description,
                    ActiveFrom = a.ActiveFrom,
                    ActiveTo = (DateTime) a.ActiveTo,
                    Type = a.ActivityType.Name,
                    Criminal = a.Criminal.FullName
                };
            }
        }
    }
}