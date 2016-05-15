namespace ProductsActions.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        public Product ()
        {
            this.Categories = new HashSet<Category>();
        }

        [Key]
        public int ProductId { get; set; }

        [MinLength(3)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [ForeignKey("Buyer")]
        public int? BuyerId { get; set; }

        public virtual User Buyer { get; set; }

        [ForeignKey("Seller")]
        public int SellerId { get; set; }

        public virtual User Seller { get; set; }

        public virtual HashSet<Category> Categories { get; set; }
    }
}
