using System.Web.Mvc;
using Tasks.Queries;

namespace Tasks.Controllers
{
    public class HomeController : ControllerBase
    {
        public ActionResult Index()
        {
            var initialData = ExecuteQuery(new HomeViewQuery());
            return View(initialData);
        }
    }
}