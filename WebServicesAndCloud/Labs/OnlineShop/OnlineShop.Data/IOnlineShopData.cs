namespace OnlineShop.Data
{
    using Models;

    public interface IOnlineShopData
    {
        IRepository<Ad> Ads { get; } 

        IRepository<AdType> AdTypes { get; }

        IRepository<ApplicationUser> Users { get; }

        IRepository<Category> Categories { get; }

        int SaveChanges();
    }
}
