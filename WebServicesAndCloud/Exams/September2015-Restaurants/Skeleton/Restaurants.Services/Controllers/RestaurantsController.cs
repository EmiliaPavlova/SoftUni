namespace Restaurants.Services.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using Microsoft.AspNet.Identity;
    using Models;
    using Restaurants.Models;

    public class RestaurantsController : BaseApiController
    {
        // GET /api/restaurants?townId={townId}
        [HttpGet]
        [Route("api/restaurants")]
        public IHttpActionResult GetAllRestaurantsByTown([FromUri]GetAllRestaurantsBindingModel model)
        {
            var ratings = new List<Rating>();
            foreach (var rat in model.Rating)
            {
                var star = this.Data.Ratings
                    .FirstOrDefault();
                ratings.Add(star);
            }
            var data = this.Data.Restaurants
                .Where(r => r.TownId == model.TownId)
                .Select(r => new RestaurantViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    //Rating = r.Ratings,
                    Town = r.Town.Name
                })
                //.OrderByDescending(r => r.Rating)
                .OrderBy(r => r.Name)
                .ToList();
;
            return this.Ok(data);
        }

        // POST /api/restaurants
        [HttpPost]
        [Authorize]
        [Route("api/restaurants")]
        public IHttpActionResult CreateRestaurant(CreateRestaurantBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (model == null)
            {
                return this.BadRequest("No data send.");
            }

            var loggedUserId = this.User.Identity.GetUserId();
            var user = this.Data.Users.Find(loggedUserId);

            var restaurant = new Restaurant()
            {
                Name = model.Name,
                TownId = model.TownId
            };

            this.Data.Restaurants.Add(restaurant);
            this.Data.SaveChanges();

            if (user != null)
            {
                return this.CreatedAtRoute(
                    "DefaultApi",
                    new {id = restaurant.Id},
                    new
                    {
                        id = restaurant.Id,
                        name = restaurant.Name,
                        rating = restaurant.Ratings,
                        town = new {id = restaurant.TownId, name = restaurant.Town.Name}
                    });
            }
            else
            {
                return this.Unauthorized();
            }
        }

        // POST /api/restaurants/{id}/rate
        [HttpPost]
        [Route("api/restaurants/{id}/rate")]
        public IHttpActionResult RateARestaurant(int id, RateRestaurantBindingModel model)
        {
            var restaurant = this.Data.Restaurants.Find(id);

            if (restaurant == null)
            {
                return this.NotFound();
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var loggedUserId = this.User.Identity.GetUserId();
            if (restaurant.OwnerId == loggedUserId)
            {
                return this.BadRequest(this.ModelState);
            }

            var rate = new Rating();

            restaurant.Ratings.Add(rate);
            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}
