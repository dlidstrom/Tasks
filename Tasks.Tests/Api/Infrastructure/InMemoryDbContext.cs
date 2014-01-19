using System.Data.Entity;
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

        public IDbSet<Person> Persons { get; set; }

        public IDbSet<TaskModel> Tasks { get; set; }

        public int SaveChanges()
        {
            return 0;
        }
    }
}