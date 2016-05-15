namespace ProductsShop.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;

    public class ProductsShopContext : DbContext
    {
        public ProductsShopContext()
            : base("name=ProductsShopContext")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion(ProductsShopContext, Configuration));
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(u => u.Friends).WithMany().Map(m =>
            {
                m.MapLeftKey("UserId");
                m.MapRightKey("FriendId");
                m.ToTable("UserFriends");
            });

            modelBuilder.Entity<User>()
                .HasMany(u => u.ProductsSold)
                .WithRequired(p => p.Seller)
                .Map(m =>
                {
                    m.MapKey("SellerId");
                });

            modelBuilder.Entity<User>()
                .HasMany(u => u.ProductsBought)
                .WithOptional(p => p.Buyer)
                .Map(m =>
                {
                    m.MapKey("BuyerId");
                });

            modelBuilder.Entity<Product>().
            HasMany(c => c.Categories).
            WithMany(p => p.Products).
            Map(
             m =>
             {
                 m.MapLeftKey("ProductId");
                 m.MapRightKey("CategoryId");
                 m.ToTable("ProductsCategories");
             });

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<User> Users { get; set; }
    }
}