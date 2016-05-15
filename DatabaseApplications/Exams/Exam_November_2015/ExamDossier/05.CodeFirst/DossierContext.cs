using _05.CodeFirst.Migrations;
using _05.CodeFirst.Models;

namespace _05.CodeFirst
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DossierContext : DbContext
    {
        
        public DossierContext() : base("DossierContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DossierContext, Configuration>());
        }

        public virtual IDbSet<Activity> Activities { get; set; }
        public virtual IDbSet<City> Cities { get; set; }
        public virtual IDbSet<Individual> Individuals { get; set; }
        public virtual IDbSet<Location> Locations { get; set; }
        public virtual IDbSet<ActivityType> ActivityTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Individual>()
                .HasMany(i => i.RelatedIndividuals)
                .WithMany()
                .Map(i =>
                {
                    i.MapLeftKey("IndividualId");
                    i.MapRightKey("RelatedId");
                    i.ToTable("RelatedIndividuals");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}