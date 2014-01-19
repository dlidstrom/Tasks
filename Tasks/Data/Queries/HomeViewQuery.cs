using System;
using System.Data.Entity;
using System.Linq;
using Tasks.Data.Models;

namespace Tasks.Data.Queries
{
    public class HomeViewQuery : IQuery<HomeViewQuery.Result>
    {
        public Result Execute(IDbContext context)
        {
            var tasks = context.Tasks
                               .Include(x => x.Responsible)
                               .ToArray()
                               .Select(x => new TaskViewModel(x));
            var people = context.Persons.ToArray();
            return new Result(tasks, people);
        }

        public class Result
        {
            public Result(object tasks, object people)
            {
                Tasks = tasks;
                People = people;
            }

            public object Tasks { get; set; }

            public object People { get; set; }
        }

        private class TaskViewModel
        {
            public TaskViewModel(TaskModel taskModel)
            {
                if (taskModel == null) throw new ArgumentNullException("taskModel");
                Task = taskModel.Task;
                Responsible = taskModel.Responsible.Name;
                Done = taskModel.Done;
            }

            public string Task { get; set; }

            public string Responsible { get; set; }

            public bool Done { get; set; }
        }
    }
}