using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriminalActivities.Data.Unit_of_Work
{
    using Models;
    using Repository;

    public interface ICriminalContext
    {
        IRepository<Activity> Activities { get; }

        IRepository<ActivityType> ActivityTypes { get; }

        IRepository<Cartel> Cartels { get; }

        IRepository<City> Cities { get; }

        IRepository<Criminal> Criminals { get; }

        IRepository<Location> Locations { get; }

        int SaveChanges();
    }
}
