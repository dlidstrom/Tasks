using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tasks.Commands;
using Tasks.Queries;

namespace Tasks.Controllers.Api
{
    public class TaskController : ApiControllerBase
    {
        public HttpResponseMessage Post(TaskRequest request)
        {
            if (ExecuteQuery(new GetTaskQuery(request.Responsible, request.Task)) != null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Task already exists");

            ExecuteCommand(new AddTaskCommand(request.Responsible, request.Task));
            var task = ExecuteQuery(new GetTaskQuery(request.Responsible, request.Task));
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