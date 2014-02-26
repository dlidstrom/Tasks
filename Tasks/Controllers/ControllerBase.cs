using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Tasks.Data.Models;
using Tasks.Data.Queries;

namespace Tasks.Controllers
{
    public abstract class ControllerBase : Controller
    {
        public IDbContext Context { get; set; }

        protected Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
        {
            if (query == null) throw new ArgumentNullException("query");
            return query.ExecuteAsync(Context);
        }
    }
}