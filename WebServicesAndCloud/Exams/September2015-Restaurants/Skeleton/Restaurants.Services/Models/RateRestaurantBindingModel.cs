namespace Restaurants.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RateRestaurantBindingModel
    {
        [Required]
        [Range(0, 10)]
        public int Rate { get; set; }
    }
}