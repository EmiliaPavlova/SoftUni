namespace _5.EFCodeFirst_Movies
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Migrations;
    using Models;

    public class MovieContext : DbContext
    {
        public MovieContext()
            : base("name=MovieContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MovieContext, Configuration>());
        }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Movie> Movies { get; set; }

        public virtual DbSet<Rating> Ratings { get; set; }
    }

}