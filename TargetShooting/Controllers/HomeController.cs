using System;
using System.Collections.Generic;
using System.Linq;
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

        // GET: Home/Calculate
        [HttpPost]
        public JsonResult Calculate()
        {
            var list = new List<Probability>();
            int total = 0;

            // 按照概率构造抽奖数组
            var probabilities = _db.Probabilities.ToList();
            foreach (Probability p in probabilities)
            {
                int value = p.Value;
                total += value;

                for (int i = 0; i < value; ++i)
                {
                    list.Add(p);
                }
            }

            // 产生随机索引值
            int index = new Random().Next(total + 1);

            Probability probability = list[index];

            return Json(new
            {
                id = probability.Id,
                imageFile = probability.ImageFile,
                ifWin = probability.IfWin
            });
        }

        // GET: Home/Win
        public ActionResult Win()
        {
            return View();
        }

        //
        // POST: /Home/Win
        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Win([Bind(Include = "Id,Name,Tel,Address")] Winner winner)
        {
            if (ModelState.IsValid)
            {
                winner.CreateTime = DateTime.Now;

                _db.Winners.Add(winner);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(winner);
        }

        // GET: Home/Lose
        public ActionResult Lose()
        {
            return View();
        }
    }
}
