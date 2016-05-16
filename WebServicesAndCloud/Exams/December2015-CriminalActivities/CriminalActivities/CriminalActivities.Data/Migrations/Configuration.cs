namespace CriminalActivities.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using Models.Enums;

    internal sealed class Configuration : DbMigrationsConfiguration<CriminalContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CriminalContext context)
        {
            if (!context.ActivityTypes.Any())
            {
                var typeNames = new[] { "DrugTrafficking", "MoneyLaundering", "Smuggling", "Racketeering", "WeaponsDealing" };
                foreach (var typeName in typeNames)
                {
                    context.ActivityTypes.Add(new ActivityType { Name = typeName });
                }

                context.SaveChanges();
            }

            if (!context.Cities.Any())
            {
                var cityNames = new[] { "Kuala Lumpur", "Little Rock", "San Francisco", "Oslo", "Huangchen", "Renshan" };
                foreach (var cityName in cityNames)
                {
                    context.Cities.Add(new City { Name = cityName });
                }

                context.SaveChanges();
            }

            if (!context.Cartels.Any())
            {
                var newCartel = new Cartel
                {
                    Name = "Guadalajara"
                };

                newCartel.Members.Add(new Criminal
                {
                    FullName = "Brian Hicks",
                    Alias = "The Gun",
                    BirthDate = new DateTime(1954, 6, 4),
                    Status = Status.Active
                });

                newCartel.Members.Add(new Criminal
                {
                    FullName = "Rachel Diaz",
                    Alias = "Death Rose",
                    BirthDate = new DateTime(1985, 12, 21),
                    Status = Status.Active
                });

                context.Cartels.Add(newCartel);

                var anotherCartel = new Cartel
                {
                    Name = "Juarez"
                };

                anotherCartel.Members.Add(new Criminal
                {
                    FullName = "George Graham",
                    Alias = "Joro The Goat",
                    BirthDate = new DateTime(1976, 6, 10),
                    Status = Status.Active
                });

                anotherCartel.Members.Add(new Criminal
                {
                    FullName = "Christine Michelle",
                    Alias = "French Kiss",
                    BirthDate = new DateTime(1990, 2, 21),
                    Status = Status.Missing
                });

                context.Cartels.Add(anotherCartel);

                context.SaveChanges();
            }
        }
    }
}
