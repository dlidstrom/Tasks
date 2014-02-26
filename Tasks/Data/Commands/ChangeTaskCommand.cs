using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Tasks.Data.Models;

namespace Tasks.Data.Commands
{
    public class ChangeTaskCommand : ICommand
    {
        private readonly string responsible;
        private readonly string task;
        private readonly bool done;

        public ChangeTaskCommand(string responsible, string task, bool done)
        {
            if (responsible == null) throw new ArgumentNullException("responsible");
            if (task == null) throw new ArgumentNullException("task");
            this.responsible = responsible;
            this.task = task;
            this.done = done;
        }

        public async Task Execute(IDbContext context)
        {
            var existingTask = await context.Tasks.SingleOrDefaultAsync(
                x => x.Responsible.Name == responsible && x.Task == task);

            if (existingTask == null)
                throw new ApplicationException("No task found");

            existingTask.SetDone(done);
        }
    }
}