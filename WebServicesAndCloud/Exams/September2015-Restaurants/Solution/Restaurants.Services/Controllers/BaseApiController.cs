namespace Restaurants.Services.Controllers
{
    using System.Web.Http;
    using Data;

    public class BaseApiController : ApiController
    {
        public BaseApiController(IRestaurantsData data)
        {
            this.Data = data;
        }

        public IRestaurantsData Data { get; set; }
    }
}