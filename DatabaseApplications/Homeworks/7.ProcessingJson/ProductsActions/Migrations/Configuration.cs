namespace ProductsActions.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    using Newtonsoft.Json;
    using ProductsActions.Data.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductsActions.Data.ProductsShopModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ProductsActions.Data.ProductsShopModel context)
        {
            if (!context.Users.Any())
            {
                // Initialize users from XML.
                var xmlDoc = XDocument.Load("../../Content/users.xml");

                var users = xmlDoc.Descendants("user");

                foreach (var user in users)
                {
                    // Create a new user.
                    var newUser = new User();
                    var fName = user.Attribute("first-name");

                    // Check if there is an attribute first-name - it is an optional parameter.
                    if (fName != null)
                    {
                        newUser.FirstName = fName.Value;
                    }

                    // Required parameter - no check required.
                    var lName = user.Attribute("last-name");
                    newUser.LastName = lName.Value;

                    // As with first-name - optional parameter.
                    var age = user.Attribute("age");
                    if (age != null)
                    {
                        newUser.Age = int.Parse(age.Value);
                    }

                    context.Users.Add(newUser);
                }

                context.SaveChanges();

                var rand = new Random();

                // Get the first possible ID;
                var startId = context.Users.First().UserId;

                // Get the last possible ID;
                var endId = context.Users.Count() + startId;

                // Initialize products from JSON.
                var json = File.ReadAllText("../../Content/products.json");
                List<Product> products = JsonConvert.DeserializeObject<List<Product>>(json);

                foreach (var product in products)
                {
                    // We'll use this to randomly assign buyers and sellers.
                    var chance = rand.Next(0, 10);
                    if (chance < 8)
                    {
                        var buyerId = rand.Next(startId, endId);
                        var buyer = context.Users.FirstOrDefault(u => u.UserId == buyerId);

                        product.Buyer = buyer;
                        buyer.BoughtProducts.Add(product);
                    }

                    // The seller can't be null - it's required.
                    var sellerId = rand.Next(startId, endId);
                    var seller = context.Users.FirstOrDefault(u => u.UserId == sellerId);
                    product.Seller = seller;
                    seller.SoldProducts.Add(product);

                    context.Products.Add(product);
                }

                context.SaveChanges();

                var productStartId = context.Products.First().ProductId;
                var productEndId = context.Products.Count() + productStartId;

                var jsonCategories = File.ReadAllText("../../Content/categories.json");
                List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(jsonCategories);
                foreach (var category in categories)
                {
                    var countProducts = rand.Next(1, 10);
                    for (int i = 0; i < countProducts; i++)
                    {
                        var num = rand.Next(productStartId, productEndId);
                        var product = context.Products.First(p => p.ProductId == num);
                        category.Products.Add(product);
                    }

                    context.Categories.Add(category);
                }

                context.SaveChanges();
            }
        }
    }
}
