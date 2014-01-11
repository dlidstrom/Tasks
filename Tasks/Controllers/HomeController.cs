using System;
using System.Web.Mvc;

namespace Tasks.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var tasks = HttpContext.Cache.Get("tasks");
            var people = HttpContext.Cache.Get("people");
            return View(new InitialData(tasks, people));
        }

        public class InitialData
        {
            public InitialData(object tasks, object people)
            {
                if (tasks == null) throw new ArgumentNullException("tasks");
                if (people == null) throw new ArgumentNullException("people");
                Tasks = tasks;
                People = people;
            }

            public object Tasks { get; set; }

            public object People { get; set; }
        }
    }
}