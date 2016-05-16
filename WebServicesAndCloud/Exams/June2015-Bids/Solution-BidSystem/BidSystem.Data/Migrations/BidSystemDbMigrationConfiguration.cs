namespace BidSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using BidSystem.Data;
    using BidSystem.Data.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public sealed class BidSystemDbMigrationConfiguration :
        DbMigrationsConfiguration<BidSystemDbContext>
    {
        public BidSystemDbMigrationConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BidSystemDbContext context)
        {
            if (!context.Users.Any())
            {
                var userPeter = CreateUser(context, "peter", "p@ssW0rd123PPP");
                var userMaria = CreateUser(context, "maria", "p@ssW0rd123MMM");
                Offer offer1 = CreateOffer(context, userPeter, "Expired Offer", null, DateTime.Now.AddDays(-5), 500, DateTime.Now.AddDays(-1));
                CreateBid(context, offer1, userPeter, 600, "Peter bid!");
                CreateBid(context, offer1, userMaria, 700, "Maria bid");
                CreateBid(context, offer1, userPeter, 800, "Peter wins!");

                Offer offer2 = CreateOffer(context, userMaria, "Active Offer", "Description", DateTime.Now.AddDays(-1), 300, DateTime.Now.AddDays(5));
                CreateBid(context, offer2, userPeter, 444, "Peter bid!");
                CreateBid(context, offer2, userMaria, 555, null);

                Offer offer3 = CreateOffer(context, userMaria, "Active Offer (New)", null, DateTime.Now, 1200, DateTime.Now.AddDays(13));
            }
        }

        private User CreateUser(BidSystemDbContext context, string username, string password)
        {
            var user = new User { UserName = username };
            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);
            var userCreateResult = userManager.Create(user, password);
            if (!userCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", userCreateResult.Errors));
            }
            return user;
        }

        private Offer CreateOffer(BidSystemDbContext context, User seller, string title, string description, DateTime publishDate, decimal initialPrice, DateTime expirationDate)
        {
            var offer = new Offer()
            {
                SellerId = seller.Id,
                Title = title,
                Description = description,
                DatePublished = publishDate,
                InitialPrice = initialPrice,
                ExpirationDateTime = expirationDate,
            };
            context.Offers.Add(offer);
            context.SaveChanges();
            return offer;
        }

        private Bid CreateBid(BidSystemDbContext context, Offer offer, User user, decimal bidPrice, string comment)
        {
            var bid = new Bid()
            {
                BidderId = user.Id,
                OfferedPrice = bidPrice,
                Comment = comment,
                OfferId = offer.Id,
                DateCreated = DateTime.Now
            };
            context.Bids.Add(bid);
            context.SaveChanges();
            return bid;
        }
    }
}
