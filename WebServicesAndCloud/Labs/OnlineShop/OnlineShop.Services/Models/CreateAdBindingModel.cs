namespace OnlineShop.Services.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreateAdBindingModel
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public int TypeId { get; set; }

        [Required]
        public decimal Price { get; set; }

        public IEnumerable<int> Categories { get; set; }
    }
}