using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Videos.Data.Migrations;
using Videos.Models;

namespace Videos.Data
{
    public class VideosDbContext : IdentityDbContext<ApplicationUser>
    {
        public VideosDbContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<VideosDbContext, Configuration>());
        }

        public static VideosDbContext Create()
        {
            return new VideosDbContext();
        }

        public virtual IDbSet<Playlist> Playlists { get; set; }

        public virtual IDbSet<Video> Videos { get; set; }

        public virtual IDbSet<Location> Locations { get; set; }

        public virtual IDbSet<Tag> Tags { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Video>()
        //        .HasMany(v => v.Tags)
        //        .WithRequired()
        //        .HasForeignKey(v => v.Id);

        //    modelBuilder.Entity<Playlist>()
        //        .HasMany(p => p.Videos)
        //        .WithRequired()
        //        .HasForeignKey(p => p.PlaylistId);




        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
