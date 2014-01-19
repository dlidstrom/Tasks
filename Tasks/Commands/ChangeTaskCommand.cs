using System;
using System.Linq;
using Tasks.Models;

namespace Tasks.Commands
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

        public void Execute(IDbContext context)
        {
            var existingTask = context.Tasks.SingleOrDefault(
                x => x.Responsible.Name == responsible
                     && x.Task == task);
            if (existingTask == null)
                throw new ApplicationException("No task found");
            existingTask.SetDone(done);
        }
    }
}