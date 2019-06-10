using System.Web.Mvc;

namespace Buchhaltung.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Bilanz";
            return View();
        }

        public ActionResult Journal()
        {
            ViewBag.Title = "Journal";
            return View();
        }

        public ActionResult Start()
        {
            ViewBag.Title = "Anfangsbeträge";
            return View();
        }
    }
}