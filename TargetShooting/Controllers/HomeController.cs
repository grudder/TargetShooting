using System;
using System.Web.Mvc;

using TargetShooting.DataAccess;
using TargetShooting.Models;

namespace TargetShooting.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

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
            if (Session["IfWin"] == null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        //
        // POST: /Home/Win
        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Win([Bind(Include = "Id,Name,Tel,Address")] Winner winner)
        {
            if (ModelState.IsValid)
            {
                winner.Ip = HttpContext.Request.UserHostAddress;
                winner.CreateTime = DateTime.Now;

                _db.Winners.Add(winner);
                _db.SaveChanges();

                Session.Remove("IfWin");
            }

            return Json(new
            {
            });
        }

        // GET: Home/Lose
        public ActionResult Lose()
        {
            return View();
        }
    }
}
