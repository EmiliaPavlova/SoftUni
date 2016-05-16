namespace Restaurants.Services.Models.BindingModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AddOrderBindingModel
    {
        [Required]
        public int Quantity { get; set; }
    }

    public class GetOrdersBindingModel
    {
        public int StartPage { get; set; }

        [Range(2, 10)]
        public int Limit { get; set; }

        public int? MealId { get; set; }
    }
}