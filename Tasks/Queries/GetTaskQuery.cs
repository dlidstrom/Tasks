using System;
using System.Linq;
using Tasks.Models;

namespace Tasks.Queries
{
    public class GetTaskQuery : IQuery<TaskModel>
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

        public TaskModel Execute(IDbContext context)
        {
            return context.Tasks.SingleOrDefault(x => x.Task == task && x.Responsible.Name == responsible);
        }
    }
}