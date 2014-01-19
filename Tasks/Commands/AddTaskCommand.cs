using System.Linq;
using Tasks.Models;

namespace Tasks.Commands
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

        public void Execute(IDbContext context)
        {
            var person = context.Persons.SingleOrDefault(x => x.Name == responsible);
            context.Tasks.Add(new TaskModel(task, person));
        }
    }
}