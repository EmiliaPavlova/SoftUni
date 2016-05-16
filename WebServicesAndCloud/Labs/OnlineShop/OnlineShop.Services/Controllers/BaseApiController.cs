namespace OnlineShop.Services.Controllers
{
    using System.Data.Entity;
    using System.Web.Http;
    using Data;
    using Infrastructure;

    public class BaseApiController : ApiController
    {
        public BaseApiController()
            : this(new OnlineShopData(new OnlineShopContext()), new AspNetUserIdProvider())
        {
        }

        public BaseApiController(IOnlineShopData data, IUserIdProvider userIdProvider)
        {
            this.Data = data;
            this.UserIdProvider = userIdProvider;
        }

        protected IOnlineShopData Data { get; set; }

        protected IUserIdProvider UserIdProvider { get; set; }
    }
}
