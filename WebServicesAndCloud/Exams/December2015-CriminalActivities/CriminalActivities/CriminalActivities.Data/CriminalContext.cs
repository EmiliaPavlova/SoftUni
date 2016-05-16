namespace CriminalActivities.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Migrations;
    using Models;

    public class CriminalContext : IdentityDbContext<User>
    {
        public CriminalContext()
            : base("name=CriminalContext")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<CriminalContext, Configuration>()
            );
        }

        public virtual IDbSet<Activity> Activities { get; set; }

        public virtual IDbSet<ActivityType> ActivityTypes { get; set; }

        public virtual IDbSet<City> Cities { get; set; }

        public virtual IDbSet<Location> Locations { get; set; }

        public virtual IDbSet<Criminal> Criminals { get; set; }

        public virtual IDbSet<Cartel> Cartels { get; set; } 

        public static CriminalContext Create()
        {
            return new CriminalContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Criminal>()
                .HasMany(i => i.Locations)
                .WithOptional(l => l.Criminal)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Criminal>()
                .HasMany(i => i.Activities)
                .WithOptional(a => a.Criminal)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Criminals)
                .WithOptional(i => i.Creator)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cartel>()
                .HasMany(c => c.Members)
                .WithOptional(c => c.Cartel)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
