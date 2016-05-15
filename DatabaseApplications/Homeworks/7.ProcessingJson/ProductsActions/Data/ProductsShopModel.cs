namespace ProductsActions.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using ProductsActions.Data.Models;
    using ProductsActions.Migrations;

    public class ProductsShopModel : DbContext
    {
        public ProductsShopModel ()
            : base("name=ProductsShopModel")
        {
            Database.SetInitializer<ProductsShopModel>(new MigrateDatabaseToLatestVersion<ProductsShopModel, Configuration>());
            //Enable-Migrations -EnableAutomaticMigrations
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
    }
}