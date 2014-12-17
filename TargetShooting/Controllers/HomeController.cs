using System.Web.Mvc;

namespace TargetShooting.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home/Index
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home/Game
        public ActionResult Game()
        {
            return View();
        }

        // GET: Home/Win
        public ActionResult Win()
        {
            return View();
        }

        // GET: Home/Lose
        public ActionResult Lose()
        {
            return View();
        }
    }
}
