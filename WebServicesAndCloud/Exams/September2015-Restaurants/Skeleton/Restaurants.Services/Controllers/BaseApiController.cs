namespace Restaurants.Services.Controllers
{
    using System.Web.Http;
    using Data;

    public class BaseApiController : ApiController
    {
        public BaseApiController()
            : this(new RestaurantsContext())
        {
        }

        public BaseApiController(RestaurantsContext data)
        {
            this.Data = data;
        }

        protected RestaurantsContext Data { get; set; }
    }
}