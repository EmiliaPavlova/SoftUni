using System;

namespace CriminalActivities.Data.Unit_of_Work
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using Models;
    using Repository;

    public class CriminalData : ICriminalContext
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public CriminalData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Activity> Activities
        {
            get { return this.GetRepository<Activity>(); }
        }

        public IRepository<ActivityType> ActivityTypes
        {
            get { return this.GetRepository<ActivityType>(); }
        }

        public IRepository<Cartel> Cartels
        {
            get { return this.GetRepository<Cartel>(); }
        }

        public IRepository<City> Cities
        {
            get { return this.GetRepository<City>(); }
        }

        public IRepository<Criminal> Criminals
        {
            get { return this.GetRepository<Criminal>(); }
        }

        public IRepository<Location> Locations
        {
            get { return this.GetRepository<Location>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>()
            where T : class
        {
            var type = typeof(T);
            if (!this.repositories.ContainsKey(type))
            {
                var typeOfRepository = typeof(GenericRepository<T>);
                var repository = Activator.CreateInstance(typeOfRepository, this.context);

                this.repositories.Add(type, repository);
            }

            return (IRepository<T>)this.repositories[type];
        }
    }
}
