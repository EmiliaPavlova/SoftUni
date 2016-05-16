namespace Restauranteur.Services.Models.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Restaurants.Models;

    public class RestaurantViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double? Rating { get; set; }

        public TownViewModel Town { get; set; }

        public static Expression<Func<Restaurant, RestaurantViewModel>> Create
        {
            get
            {
                return r => new RestaurantViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Town = new TownViewModel
                    {
                        Id = r.Town.Id,
                        Name = r.Town.Name
                    },
                    Rating = r.Ratings.Average(rt => rt.Stars),
                };
            }
        }
    }

    public class TownViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}