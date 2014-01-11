using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Tasks.Models;

namespace Tasks.Controllers.Api
{
    public class TaskController : ApiController
    {
        public HttpResponseMessage Post(TaskRequest request)
        {
            var tasks = (List<TaskModel>)HttpContext.Current.Cache.Get("tasks");
            if (tasks.Any(x => x.Task == request.Task && x.Responsible == request.Responsible))
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Task already exists");

            tasks.Add(new TaskModel(request.Task, request.Responsible));
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        public HttpResponseMessage Put(TaskRequest request)
        {
            var tasks = (List<TaskModel>)HttpContext.Current.Cache.Get("tasks");
            var task = tasks.SingleOrDefault(x => x.Task == request.Task && x.Responsible == request.Responsible);
            if (task == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No task found");

            task.SetDone(request.Done);
            return Request.CreateResponse(HttpStatusCode.Accepted);
        }

        public HttpResponseMessage Delete([FromUri] TaskRequest request)
        {
            var tasks = (List<TaskModel>)HttpContext.Current.Cache.Get("tasks");
            var task = tasks.SingleOrDefault(x => x.Task == request.Task && x.Responsible == request.Responsible);
            if (task != null) tasks.Remove(task);
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