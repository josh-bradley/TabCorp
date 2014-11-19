using System.Web.Mvc;

namespace TabCorp.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MainCtrl()
        {
            return View();
        }
    }
}