namespace Restaurants.Services.Models.ViewModels
{
    using System;
    using System.Linq.Expressions;
    using Restauranteur.Models;
    using Restaurants.Models;

    public class OrderViewModel
    {
        public int Id { get; set; }

        public MealViewModel Meal { get; set; }

        public int Quantity { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public static Expression<Func<Order, OrderViewModel>> Create
        {
            get
            {
                return o => new OrderViewModel
                {
                    Id = o.Id,
                    Meal = new MealViewModel()
                    {
                        Id = o.Meal.Id,
                        Name = o.Meal.Name,
                        Price = o.Meal.Price,
                        Type = o.Meal.Type.Name
                    },
                    Status = o.OrderStatus,
                    CreatedOn = o.CreatedOn,
                    Quantity = o.Quantity
                };
            }
        }
    }
}