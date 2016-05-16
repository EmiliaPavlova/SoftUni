using System.Security.Cryptography;
using Videos.Models;

namespace Videos.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VideosDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(VideosDbContext context)
        {
            var location = new Location()
            {
                Country = "Hell",
                City = "FuckU"
            };

            context.SaveChanges();
        }
    }
}
