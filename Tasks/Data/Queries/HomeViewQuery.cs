using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Tasks.Data.Models;

namespace Tasks.Data.Queries
{
    public class HomeViewQuery : IQuery<HomeViewQuery.Result>
    {
        public async Task<Result> ExecuteAsync(IDbContext context)
        {
            var tasks = await context.Tasks
                                     .Include(x => x.Responsible)
                                     .ToArrayAsync();
            var people = await context.Persons.ToArrayAsync();
            return new Result(tasks.Select(x => new TaskViewModel(x)), people);
        }

        public class Result
        {
            public Result(object tasks, object people)
            {
                Tasks = tasks;
                People = people;
            }

            public object Tasks { get; private set; }

            public object People { get; private set; }
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

            public string Task { get; private set; }

            public string Responsible { get; private set; }

            public bool Done { get; private set; }
        }
    }
}