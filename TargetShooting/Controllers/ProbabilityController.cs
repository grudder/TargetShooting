using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

using PagedList;

using TargetShooting.DataAccess;
using TargetShooting.Models;

namespace TargetShooting.Controllers
{
    public class ProbabilityController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        //
        // GET: /Probability/
        //
        public ActionResult Index(int? page)
        {
            var probabilities = from i in _db.Probabilities
                                orderby i.Id
                                select i;

            // 分页
            const int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(probabilities.ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /Probability/Details/5
        //
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Probability probability = _db.Probabilities.Find(id);
            if (probability == null)
            {
                return HttpNotFound();
            }
            return View(probability);
        }

        //
        // GET: /Probability/Create
        //
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Probability/Create
        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Position,Value")] Probability probability)
        {
            if (ModelState.IsValid)
            {
                _db.Probabilities.Add(probability);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(probability);
        }

        //
        // GET: /Probability/Edit/5
        //
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Probability probability = _db.Probabilities.Find(id);
            if (probability == null)
            {
                return HttpNotFound();
            }
            return View(probability);
        }

        //
        // POST: /Probability/Edit/5
        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Position,Value")] Probability probability)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(probability).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(probability);
        }

        //
        // GET: /Probability/Delete/5
        //
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Probability probability = _db.Probabilities.Find(id);
            if (probability == null)
            {
                return HttpNotFound();
            }
            return View(probability);
        }

        //
        // POST: /Probability/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Probability probability = _db.Probabilities.Find(id);
            _db.Probabilities.Remove(probability);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
