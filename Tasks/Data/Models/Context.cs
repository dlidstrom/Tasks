using System.Data.Entity;

namespace Tasks.Data.Models
{
    public class Context : DbContext, IDbContext
    {
        public Context()
            : base("TasksContext")
        {
        }

        public IDbSet<Person> Persons { get; set; }

        public IDbSet<TaskModel> Tasks { get; set; }
    }
}