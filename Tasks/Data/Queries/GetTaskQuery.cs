using System;
using System.Linq;
using Tasks.Data.Models;

namespace Tasks.Data.Queries
{
    public class GetTaskQuery : IQuery<GetTaskQuery.Result>
    {
        private readonly string responsible;
        private readonly string task;

        public GetTaskQuery(string responsible, string task)
        {
            if (responsible == null) throw new ArgumentNullException("responsible");
            if (task == null) throw new ArgumentNullException("task");
            this.responsible = responsible;
            this.task = task;
        }

        public Result Execute(IDbContext context)
        {
            var local = context.Tasks.Local.SingleOrDefault(x => x.Task == task && x.Responsible.Name == responsible);
            if (local != null) return new Result(local);
            var existing = context.Tasks.SingleOrDefault(x => x.Task == task && x.Responsible.Name == responsible);
            return existing != null ? new Result(existing) : null;
        }

        public class Result
        {
            public Result(TaskModel taskModel)
            {
                Responsible = taskModel.Responsible.Name;
                Task = taskModel.Task;
                Done = taskModel.Done;
            }

            public string Responsible { get; set; }

            public string Task { get; set; }

            public bool Done { get; set; }
        }
    }
}