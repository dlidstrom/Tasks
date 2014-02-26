using System.Data.Entity;
using System.Threading.Tasks;
using Tasks.Data.Models;

namespace Tasks.Data.Commands
{
    public class AddTaskCommand : ICommand
    {
        private readonly string responsible;
        private readonly string task;

        public AddTaskCommand(string responsible, string task)
        {
            this.responsible = responsible;
            this.task = task;
        }

        public async Task Execute(IDbContext context)
        {
            var person = await context.Persons.SingleOrDefaultAsync(x => x.Name == responsible);
            context.Tasks.Add(new TaskModel(task, person));
        }
    }
}