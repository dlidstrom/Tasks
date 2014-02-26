using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Tasks.Data.Commands;
using Tasks.Data.Queries;

namespace Tasks.Controllers.Api
{
    public class TaskController : ApiControllerBase
    {
        public async Task<HttpResponseMessage> Post(TaskRequest request)
        {
            if (await ExecuteQueryAsync(new GetTaskQuery(request.Responsible, request.Task)) != null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Task already exists");

            ExecuteCommand(new AddTaskCommand(request.Responsible, request.Task));
            var task = await ExecuteQueryAsync(new GetTaskQuery(request.Responsible, request.Task));
            return Request.CreateResponse(
                HttpStatusCode.Created,
                task);
        }

        public HttpResponseMessage Put(TaskRequest request)
        {
            ExecuteCommand(new ChangeTaskCommand(request.Responsible, request.Task, request.Done));
            return Request.CreateResponse(HttpStatusCode.Accepted);
        }

        public HttpResponseMessage Delete([FromUri] TaskRequest request)
        {
            ExecuteCommand(new DeleteTaskCommand(request.Responsible, request.Task));
            return Request.CreateResponse(HttpStatusCode.Accepted);
        }

        public class TaskRequest
        {
            public string Task { get; set; }

            public string Responsible { get; set; }

            public bool Done { get; set; }
        }
    }
}