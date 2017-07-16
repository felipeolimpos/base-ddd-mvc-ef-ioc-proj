using System.Web.Mvc;

namespace POS.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Error()
        {
            ViewBag.Error = true;
            return View("Index");
        }
    }
}