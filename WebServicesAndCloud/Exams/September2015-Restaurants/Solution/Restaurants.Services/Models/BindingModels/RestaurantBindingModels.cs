namespace Restauranteur.Services.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class SearchRestaurantsBindingModel
    {
        [Required]
        public int TownId { get; set; }
    }

    public class AddRestaurantBindingModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int TownId { get; set; }
    }

    public class RateRestaurantBindingModel
    {
        [Range(1, 10)]
        public int Stars { get; set; }
    }
}