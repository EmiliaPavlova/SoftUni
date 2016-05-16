namespace BidSystem.Tests.Mocks
{
    using BidSystem.Data.Models;
    using BidSystem.Data.Repositories;
    using BidSystem.Data.UnitOfWork;

    using Microsoft.AspNet.Identity;

    public class BidSystemDataMock : IBidSystemData
    {
        private GenericRepositoryMock<User> usersMock = new GenericRepositoryMock<User>();
        private GenericRepositoryMock<Offer> offersMock = new GenericRepositoryMock<Offer>();
        private GenericRepositoryMock<Bid> bidsMock = new GenericRepositoryMock<Bid>();
        private GenericUserStoreMock<User> userStoreMock = new GenericUserStoreMock<User>();

        public bool ChangesSaved { get; set; }

        public IRepository<User> Users {
            get { return this.usersMock; }
        }

        public IRepository<Offer> Offers
        {
            get { return this.offersMock; }
        }

        public IRepository<Bid> Bids
        {
            get { return this.bidsMock; }
        }

        public IUserStore<User> UserStore
        {
            get { return this.userStoreMock; }
        }

        public void SaveChanges()
        {
            this.ChangesSaved = true;
        }
    }
}
