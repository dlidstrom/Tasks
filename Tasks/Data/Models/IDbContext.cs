using System.Data.Entity;
using System.Threading.Tasks;

namespace Tasks.Data.Models
{
    public interface IDbContext
    {
        IDbSet<Person> Persons { get; }

        IDbSet<TaskModel> Tasks { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}