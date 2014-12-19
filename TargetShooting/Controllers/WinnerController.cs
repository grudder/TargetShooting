using System.Linq;
using System.Web.Mvc;

using PagedList;

using TargetShooting.DataAccess;

namespace TargetShooting.Controllers
{
    public class WinnerController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        //
        // GET: /Winner/
        //
        public ActionResult Index(int? page)
        {
            var winners = from i in _db.Winners
                                orderby i.Id
                                select i;

            // 分页
            const int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(winners.ToPagedList(pageNumber, pageSize));
        }
    }
}
