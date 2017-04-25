using Net.SSO.Client.Web1.App_Start;
using System.Web.Mvc;

namespace Net.SSO.Client.Web1.Controllers
{
    [CheckLogin]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}