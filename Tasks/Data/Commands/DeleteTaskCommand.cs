using System;
using System.Data.Entity;
using System.Threading.Tasks;
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

        public async Task Execute(IDbContext context)
        {
            var existingTask = await context.Tasks.SingleOrDefaultAsync(
                x => x.Responsible.Name == responsible && x.Task == task);

            if (existingTask != null)
                context.Tasks.Remove(existingTask);
        }
    }
}