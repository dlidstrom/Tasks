using System.Web.Http.Filters;
using Tasks.Controllers.Api;

namespace Tasks.Infrastructure
{
    public class SaveChangesAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var controller = actionExecutedContext.ActionContext.ControllerContext.Controller as ApiControllerBase;
            if (controller == null || actionExecutedContext.Exception != null)
                return;

            controller.Context.SaveChanges();
        }
    }
}