using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CriminalActivities.App.Models
{
    using System.Linq.Expressions;
    using CriminalActivities.Models;
    using CriminalActivities.Models.Enums;

    public class CriminalViewModel
    {
        public string Name { get; set; }

        public string Alias { get; set; }

        public DateTime? BirthDate { get; set; }

        public Status Status { get; set; }

        public static Expression<Func<Criminal, CriminalViewModel>> Create
        {
            get
            {
                return c => new CriminalViewModel()
                {
                    Name = c.FullName,
                    Alias = c.Alias,
                    BirthDate = c.BirthDate,
                    Status = c.Status
                };
            }
        }
    }
}