using System.Data.Entity;
using System.Threading.Tasks;
using Tasks.Data.Models;

namespace Tasks.Tests.Api.Infrastructure
{
    public class InMemoryDbContext : IDbContext
    {
        public InMemoryDbContext()
        {
            Persons = new InMemoryDbSet<Person>();
            Tasks = new InMemoryDbSet<TaskModel>();
        }

        public IDbSet<Person> Persons { get; private set; }

        public IDbSet<TaskModel> Tasks { get; private set; }

        public Task<int> SaveChangesAsync()
        {
            return Task.FromResult(0);
        }
    }
}