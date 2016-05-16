using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CriminalActivities.App.Models
{
    using System.Linq.Expressions;
    using CriminalActivities.Models;
    using CriminalActivities.Models.Enums;

    public class RegisteredCriminalViewModel
	{
        public string Name { get; set; }

        public string Alias { get; set; }

        public Status Status { get; set; }

        public string RegisteredBy { get; set; }

        public static Expression<Func<Criminal, RegisteredCriminalViewModel>> Create
        {
            get
            {
                return c => new RegisteredCriminalViewModel()
                {
                    Name = c.FullName,
                    Alias = c.Alias,
                    Status = c.Status,
					RegisteredBy = c.Creator.UserName
                };
            }
        }

    }
}