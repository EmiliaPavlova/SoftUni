namespace Restaurants.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Data;
    using Microsoft.AspNet.Identity;
    using Models.BindingModels;
    using Models.ViewModels;
    using Restaurants.Models;

    [Authorize]
    public class OrdersController : BaseApiController
    {
        public OrdersController(IRestaurantsData data) 
            : base(data)
        {
        }

        [HttpPost]
        [Route("api/meals/{id}/order")]
        public IHttpActionResult Order(int id, AddOrderBindingModel model)
        {
            var meal = this.Data.Meals.Find(id);
            if (meal == null)
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
            
            var loggedUserId = this.User.Identity.GetUserId();
            var order = new Order
            {
                MealId = id,
                Quantity = model.Quantity,
                UserId = loggedUserId,
                CreatedOn = DateTime.Now
            };

            this.Data.Orders.Add(order);
            this.Data.SaveChanges();

            return this.Ok();
        }

        [HttpGet]
        public IHttpActionResult GetOwnOrders([FromUri]GetOrdersBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Model cannot be null");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var userOrders = this.Data.Orders.All();

            if (model.MealId.HasValue)
            {
                userOrders = userOrders
                    .Where(o => o.MealId == model.MealId);
            }
            
            var loggedUserId = this.User.Identity.GetUserId();

            var data = userOrders
                .Where(o => o.UserId == loggedUserId &&
                            o.OrderStatus == OrderStatus.Pending)
                .OrderByDescending(o => o.CreatedOn)
                .Skip(model.StartPage * model.Limit)
                .Take(model.Limit)
                .Select(OrderViewModel.Create);

            return this.Ok(data);
        }
    }
}