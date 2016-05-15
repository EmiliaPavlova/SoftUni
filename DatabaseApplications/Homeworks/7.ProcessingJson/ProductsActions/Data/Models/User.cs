namespace ProductsActions.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User ()
        {
            this.BoughtProducts = new HashSet<Product>();
            this.SoldProducts = new HashSet<Product>();
            this.Friends = new HashSet<User>();
        }

        [Key]
        public int UserId { get; set; }

        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        public string LastName { get; set; }

        public int? Age { get; set; }

        public virtual HashSet<Product> BoughtProducts { get; set; }

        public virtual HashSet<Product> SoldProducts { get; set; }

        public virtual HashSet<User> Friends { get; set; }
    }
}
