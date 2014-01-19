using System;
using System.Web.Mvc;
using Tasks.Data.Models;
using Tasks.Data.Queries;

namespace Tasks.Controllers
{
    public abstract class ControllerBase : Controller
    {
        public IDbContext Context { get; set; }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.IsChildAction || filterContext.Exception != null) return;
            Context.SaveChanges();
        }

        protected TResult ExecuteQuery<TResult>(IQuery<TResult> query)
        {
            if (query == null) throw new ArgumentNullException("query");
            return query.Execute(Context);
        }
    }
}