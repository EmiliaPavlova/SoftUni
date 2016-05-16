namespace BugTracker.RestServices.Controllers
{
    using System.Web.Http;
    using Data;

    public class BaseApiController : ApiController
    {
        public BaseApiController()
        {
            this.Data = new BugTrackerDbContext();
        }

        protected BugTrackerDbContext Data { get; set; }
    }
}
