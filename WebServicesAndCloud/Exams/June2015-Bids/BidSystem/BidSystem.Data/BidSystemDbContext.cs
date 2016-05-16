namespace BidSystem.Data
{
    using System.Data.Entity;

    using BidSystem.Data.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class BidSystemDbContext : IdentityDbContext<User>
    {
        public BidSystemDbContext()
            : base("BidSystem")
        {
        }
        
        public static BidSystemDbContext Create()
        {
            return new BidSystemDbContext();
        }

        public DbSet<Offer> Offers { get; set; }

        public DbSet<Bid> Bids { get; set; }
    }
}
