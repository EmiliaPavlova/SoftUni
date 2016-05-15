namespace ProductsActions.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        public Category ()
        {
            this.Products = new HashSet<Product>();
        }

        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public string Name { get; set; }

        public virtual HashSet<Product> Products { get; set; }
    }
}
