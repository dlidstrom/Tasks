using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using Tasks.Controllers.Api;

namespace Tasks.Infrastructure
{
    public class SaveChangesAttribute : AsyncFilter
    {
        protected override async Task InternalActionExecuted(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            var controller = actionExecutedContext.ActionContext.ControllerContext.Controller as ApiControllerBase;
            if (controller != null && actionExecutedContext.Exception == null)
                await controller.Context.SaveChangesAsync();
        }
    }
}