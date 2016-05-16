namespace Restauranteur.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Microsoft.AspNet.Identity;
    using Models.BindingModels;
    using Restaurants.Data;
    using Restaurants.Models;
    using Restaurants.Services.Controllers;
    using Restaurants.Services.Models.ViewModels;

    [Authorize]
    public class MealsController : BaseApiController
    {
        public MealsController(IRestaurantsData data)
            : base(data)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/restaurants/{restarauntId}/meals")]
        public IHttpActionResult GetMeals(int restarauntId)
        {
            var restaurant = this.Data.Restaurants.Find(restarauntId);
            if (restaurant == null)
            {
                return this.NotFound();
            }

            var meals = this.Data.Meals.All()
                .Where(m => m.RestaurantId == restarauntId)
                .OrderBy(m => m.Type.Order)
                .ThenBy(m => m.Price)
                .Select(MealViewModel.Create);

            return this.Ok(meals);
        }

        [HttpPost]
        [Route("api/meals")]
        public IHttpActionResult AddMeal(AddMealBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Model cannot be null");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var restaurant = this.Data.Restaurants.Find(model.RestaurantId);
            if (restaurant == null)
            {
                return this.BadRequest("Invalid restaurant id: " + model.RestaurantId);
            }

            var loggerUserId = this.User.Identity.GetUserId();
            if (restaurant.OwnerId != loggerUserId)
            {
                return this.Unauthorized();
            }

            var type = this.Data.MealTypes.Find(model.TypeId);
            if (type == null)
            {
                return this.BadRequest("Invalid meal type id: " + model.TypeId);
            }
            
            var meal = new Meal()
            {
                Name = model.Name,
                Price = model.Price,
                RestaurantId = model.RestaurantId,
                TypeId = model.TypeId
            };

            this.Data.Meals.Add(meal);
            this.Data.SaveChanges();

            var mealData = this.Data.Meals.All()
                .Where(m => m.Id == meal.Id)
                .Select(MealViewModel.Create)
                .FirstOrDefault();

            return this.CreatedAtRoute("DefaultApi",
                new { controller = "meals", id = meal.Id },
                mealData);
        }

        [HttpPut]
        [Route("api/meals/{id}")]
        public IHttpActionResult EditMeal(int id, EditMealBindingModel model)
        {
            var meal = this.Data.Meals.Find(id);
            if (meal == null)
            {
                return this.NotFound();
            }

            var loggerUserId = this.User.Identity.GetUserId();
            var restaurantOwnerId = this.GetRestaurantOwnerId(meal.RestaurantId);

            if (restaurantOwnerId != loggerUserId)
            {
                return this.Unauthorized();
            }

            if (model == null)
            {
                return this.BadRequest("Model cannot be null");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var type = this.Data.MealTypes.Find(model.TypeId);
            if (type == null)
            {
                return this.BadRequest("Invalid meal type id: " + model.TypeId);
            }

            meal.Type = type;
            meal.Price = model.Price;
            meal.Name = model.Name;
            this.Data.SaveChanges();

            var mealData = this.Data.Meals.All()
                .Where(m => m.Id == meal.Id)
                .Select(MealViewModel.Create)
                .FirstOrDefault();

            return this.Ok(mealData);
        }

        [HttpDelete]
        [Route("api/meals/{id}")]
        public IHttpActionResult DeleteMeal(int id)
        {
            var meal = this.Data.Meals.Find(id);
            if (meal == null)
            {
                return this.NotFound();
            }

            var loggerUserId = this.User.Identity.GetUserId();
            var restaurantOwnerId = this.GetRestaurantOwnerId(meal.RestaurantId);

            if (restaurantOwnerId != loggerUserId)
            {
                return this.Unauthorized();
            }

            this.Data.Meals.Delete(meal);
            this.Data.SaveChanges();

            return this.Ok();
        }

        private string GetRestaurantOwnerId(int restaurantId)
        {
            return this.Data.Restaurants.All()
                .Where(r => r.Id == restaurantId)
                .Select(r => r.OwnerId)
                .FirstOrDefault();
        }
    }
}