using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;
using ProductsActions.Data;

namespace ProductsActions
{
    public class Program
    {
        private static ProductsShopModel ctx = new ProductsShopModel();

        public static void Main (string[] args)
        {
            // 1st query
            GetProductsInRange();

            // 4th query
            GetSellers();
        }

        private static void GetProductsInRange ()
        {
            var minPrice = 500m;
            var maxPrice = 1000m;

            var products = ctx.Products
                .Where(p => minPrice <= p.Price && p.Price <= maxPrice && p.Buyer == null)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName
                })
                .ToList();

            var jsonObj = JsonConvert.SerializeObject(products);
            File.WriteAllText("products-in-range.json", jsonObj);
        }

        private static void GetSellers ()
        {
            var users = ctx.Users.ToList();
            var sellers = ctx.Users
                .Where(u => u.SoldProducts.Any())
                .OrderByDescending(u => u.SoldProducts.Count)
                .ThenBy(u => u.LastName)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    Products = u.SoldProducts.Select(p => new
                    {
                        p.Name,
                        p.Price
                    })
                })
                .ToList();

            var xmlDoc = new XDocument();
            // The root element.
            var root = new XElement("users");
            root.SetAttributeValue("count", sellers.Count);
            foreach (var seller in sellers)
            {
                var userElement = new XElement("user");
                if (!string.IsNullOrEmpty(seller.FirstName))
                {
                    userElement.SetAttributeValue("first-name", seller.FirstName);
                }

                userElement.SetAttributeValue("last-name", seller.LastName);

                if (seller.Age != null)
                {
                    userElement.SetAttributeValue("age", seller.Age);
                }

                var soldItemsElement = new XElement("sold-items");
                soldItemsElement.SetAttributeValue("count", seller.Products.Count());
                foreach (var soldProduct in seller.Products)
                {
                    var productElement = new XElement("product");
                    productElement.SetAttributeValue("name", soldProduct.Name);
                    productElement.SetAttributeValue("price", soldProduct.Price);

                    // Add to top item the current element.
                    soldItemsElement.Add(productElement);
                }

                // Add items wrapper to user element.
                userElement.Add(soldItemsElement);

                // Add user to wrapper root element.
                root.Add(userElement);
            }

            // Add root to doc.
            xmlDoc.Add(root);

            var xmlStr = xmlDoc.ToString();
            File.WriteAllText("sellers.xml", xmlStr);
        }
    }
}
