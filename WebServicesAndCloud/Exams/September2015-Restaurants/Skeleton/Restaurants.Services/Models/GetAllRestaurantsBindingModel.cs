using System.Collections.Generic;

namespace Restaurants.Services.Models
{
    public class GetAllRestaurantsBindingModel
    {
        internal readonly IEnumerable<object> Rating;

        public int TownId { get; set; }
    }
}