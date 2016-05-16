namespace Restaurants.Services.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Antlr.Runtime.Misc;
    using Restaurants.Models;

    public class RestaurantViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //public IEnumerable<Rating> Rating { get; set; }

        public string Town { get; set; }
    }
}