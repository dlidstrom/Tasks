using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Tasks.Infrastructure
{
    // see http://www.strathweb.com/2013/11/asynchronous-action-filters-asp-net-web-api/
    public class AsyncFilter : FilterAttribute, IActionFilter
    {
        public async Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken,
            Func<Task<HttpResponseMessage>> continuation)
        {
            await InternalActionExecuting(actionContext, cancellationToken);

            if (actionContext.Response != null)
            {
                return actionContext.Response;
            }

            HttpActionExecutedContext executedContext;

            try
            {
                var response = await continuation();
                executedContext = new HttpActionExecutedContext(actionContext, null)
                {
                    Response = response
                };
            }
            catch (Exception exception)
            {
                executedContext = new HttpActionExecutedContext(actionContext, exception);
            }

            await InternalActionExecuted(executedContext, cancellationToken);
            return executedContext.Response;
        }

        protected virtual Task InternalActionExecuting(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            //pre execution hook
            return Task.FromResult(0);
        }

        protected virtual Task InternalActionExecuted(HttpActionExecutedContext actionExecutedContext,
            CancellationToken cancellationToken)
        {
            //post execution hook
            return Task.FromResult(0);
        }
    }
}