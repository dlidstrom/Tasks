using System.Data.Entity;

namespace Tasks.Models
{
    public interface IDbContext
    {
        IDbSet<Person> Persons { get; set; }

        IDbSet<TaskModel> Tasks { get; set; }

        int SaveChanges();
    }
}