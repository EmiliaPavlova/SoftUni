namespace Restauranteur.Services.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class EditMealBindingModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int TypeId { get; set; }
    }

    public class AddMealBindingModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int TypeId { get; set; }

        [Required]
        public int RestaurantId { get; set; }
    }
}