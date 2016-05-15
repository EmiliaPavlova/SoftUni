using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsShop.Client
{
    using System.Xml.Linq;
    using Data;
    using Newtonsoft.Json;
    using Formatting = System.Xml.Formatting;

    class Program
    {
        static void Main(string[] args)
        {
            // Query 1
            GetProductsInRangeWithouABuyer(500, 1000);+

            // Query 2
            //GellAllUsersSoldAnITem();

            // Query 3
            //GetAllCategories();

            // Query 4
            //GetUsersWithProductsToXml();
        }

        private static void GetProductsInRangeWithouABuyer(int minPrice, int maxPrice)
        {
            var ctx = new ProductsShopContext();

            var filteredProducts = ctx.Products
                .Where(p => p.Price >= minPrice && p.Price <= maxPrice && p.Buyer == null)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName
                });

            var json = JsonConvert.SerializeObject(filteredProducts, Newtonsoft.Json.Formatting.Indented);

            Console.WriteLine(json);
        }
        private static void GellAllUsersSoldAnITem()
        {
            var ctx = new ProductsShopContext();

            var filteredUsers = ctx.Users
                .Where(u => u.ProductsSold.Count > 0)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold
                    .Where(p => p.Buyer != null)
                    .Select(ps => new
                    {
                        name = ps.Name,
                        price = ps.Price,
                        buyerFirstName = ps.Buyer.FirstName,
                        buyerLastName = ps.Buyer.LastName

                    })
                });

            var json = JsonConvert.SerializeObject(filteredUsers, Newtonsoft.Json.Formatting.Indented);

            Console.WriteLine(json);
        }

        private static void GetAllCategories()
        {
            var ctx = new ProductsShopContext();

            var filteredCategories = ctx.Categories.OrderByDescending(c => c.Products.Count).Select(c => new
            {
                category = c.Name,
                productsCount = c.Products.Count,
                averagePrice = c.Products.Sum(p => p.Price) / c.Products.Count,
                totalRevenue = c.Products.Sum(p => p.Price)
            });

            var json = JsonConvert.SerializeObject(filteredCategories, Newtonsoft.Json.Formatting.Indented);

            Console.WriteLine(json);
        }

        private static void GetUsersWithProductsToXml()
        {
            var ctx = new ProductsShopContext();

            var filteredUsers =
                ctx.Users.Where(u => u.ProductsSold.Count > 0)
                    .OrderByDescending(u => u.ProductsSold.Count)
                    .ThenBy(u => u.LastName)
                    .Select(u => new
                    {
                        u.FirstName,
                        u.LastName,
                        u.Age,
                        productsSold = u.ProductsSold.Select(p => new
                        {
                            p.Name,
                            p.Price
                        })

                    }).ToList();

            XDeclaration declaration = new XDeclaration("1.0", "utf-8", null);

            XDocument xml = new XDocument();

            xml.Declaration = declaration;

            var root = new XElement("users");

            root.Add(new XAttribute("count", filteredUsers.Count));

            xml.Add(root);


            foreach (var filteredUser in filteredUsers)
            {
                var user = new XElement("user");

                if (filteredUser.FirstName != null)
                {
                    user.Add(new XAttribute("first-name", filteredUser.FirstName));
                }

                user.Add(new XAttribute("last-name", filteredUser.LastName));

                if (filteredUser.Age != null)
                {
                    user.Add(new XAttribute("age", filteredUser.Age));
                }

                var productsSold = new XElement("sold-products");
                productsSold.Add(new XAttribute("count", filteredUser.productsSold.Count()));

                foreach (var product in filteredUser.productsSold)
                {
                    var productNode = new XElement("product");

                    productNode.Add(new XAttribute("name", product.Name));
                    productNode.Add(new XAttribute("price", product.Price));

                    productsSold.Add(productNode);
                }

                user.Add(productsSold);
                root.Add(user);
            }

            xml.Save("../../../doc.xml");

            Console.WriteLine(xml);
        }
    }
}
