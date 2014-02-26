using System.Threading.Tasks;
using System.Web.Mvc;
using Tasks.Data.Queries;

namespace Tasks.Controllers
{
    public class HomeController : ControllerBase
    {
        public async Task<ActionResult> Index()
        {
            var initialData = await ExecuteQueryAsync(new HomeViewQuery());
            return View(initialData);
        }
    }
}