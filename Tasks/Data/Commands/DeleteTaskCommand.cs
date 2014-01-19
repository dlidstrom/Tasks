using System;
using System.Linq;
using Tasks.Data.Models;

namespace Tasks.Data.Commands
{
    public class DeleteTaskCommand : ICommand
    {
        private readonly string responsible;
        private readonly string task;

        public DeleteTaskCommand(string responsible, string task)
        {
            if (responsible == null) throw new ArgumentNullException("responsible");
            if (task == null) throw new ArgumentNullException("task");
            this.responsible = responsible;
            this.task = task;
        }

        public void Execute(IDbContext context)
        {
            var existingTask = context.Tasks
                                      .SingleOrDefault(x => x.Responsible.Name == responsible
                                                            && x.Task == task);
            if (existingTask != null)
                context.Tasks.Remove(existingTask);
        }
    }
}