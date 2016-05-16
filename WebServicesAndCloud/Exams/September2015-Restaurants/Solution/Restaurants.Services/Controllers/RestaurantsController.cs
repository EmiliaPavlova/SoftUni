namespace Restauranteur.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Microsoft.AspNet.Identity;
    using Models.BindingModels;
    using Models.ViewModels;
    using Restaurants.Data;
    using Restaurants.Models;
    using Restaurants.Services.Controllers;

    [Authorize]
    public class RestaurantsController : BaseApiController
    {
        public RestaurantsController(IRestaurantsData data) 
            : base(data)
        {
        }

        [AllowAnonymous]
        public IHttpActionResult GetRestaurants(
            [FromUri]SearchRestaurantsBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Model cannot be null.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var data = this.Data.Restaurants.All()
                .Where(r => r.TownId == model.TownId)
                .OrderByDescending(r => r.Ratings.Average(rt => rt.Stars))
                .ThenBy(r => r.Name)
                .Select(RestaurantViewModel.Create)
                .ToList();

            return this.Ok(data);
        }

        [HttpPost]
        public IHttpActionResult AddRestaurant(AddRestaurantBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("No data was sent.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var town = this.Data.Towns.Find(model.TownId);
            if (town == null)
            {
                return this.BadRequest("Invalid town id: " + model.TownId);
            }

            var loggedUserId = this.User.Identity.GetUserId();

            var restaurant = new Restaurant
            {
                Name = model.Name,
                TownId = town.Id,
                OwnerId = loggedUserId
            };

            this.Data.Restaurants.Add(restaurant);
            this.Data.SaveChanges();

            var restaurantData = this.Data.Restaurants.All()
                .Where(r => r.Id == restaurant.Id)
                .Select(RestaurantViewModel.Create)
                .FirstOrDefault();

            return this.CreatedAtRoute(
                "DefaultApi",
                new { controller = "restaurants", id = restaurant.Id }, 
                restaurantData);
        }

        [HttpPost]
        [Route("api/restaurants/{id}/rate")]
        public IHttpActionResult Rate(int id, RateRestaurantBindingModel model)
        {
            var restaurant = this.Data.Restaurants.Find(id);
            if (restaurant == null)
            {
                return this.NotFound();
            }

            if (model == null)
            {
                return this.BadRequest("Model cannot be null.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var loggedInUserId = this.User.Identity.GetUserId();
            if (loggedInUserId == restaurant.OwnerId)
            {
                return this.BadRequest("Cannot rate own restaurant.");
            }

            var rating = restaurant.Ratings.FirstOrDefault(r => r.UserId == loggedInUserId);
            if (rating != null)
            {
                rating.Stars = model.Stars;
            }
            else
            {
                rating = new Rating
                {
                    RestaurantId = restaurant.Id,
                    UserId = loggedInUserId,
                    Stars = model.Stars
                };

                this.Data.Ratings.Add(rating);
            }

            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}