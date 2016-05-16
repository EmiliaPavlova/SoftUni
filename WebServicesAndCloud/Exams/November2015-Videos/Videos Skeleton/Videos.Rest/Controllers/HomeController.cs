using System.Web.Mvc;

namespace Videos.Rest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return this.Redirect("Help");
        }
    }
}