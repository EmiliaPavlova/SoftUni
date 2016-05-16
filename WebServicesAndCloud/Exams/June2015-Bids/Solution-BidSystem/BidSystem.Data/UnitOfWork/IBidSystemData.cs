namespace BidSystem.Data.UnitOfWork
{
    using BidSystem.Data.Models;
    using BidSystem.Data.Repositories;

    using Microsoft.AspNet.Identity;

    public interface IBidSystemData
    {
        IRepository<User> Users { get; }

        IRepository<Offer> Offers { get; }
        
        IRepository<Bid> Bids { get; }

        IUserStore<User> UserStore { get; }

        void SaveChanges();
    }
}
