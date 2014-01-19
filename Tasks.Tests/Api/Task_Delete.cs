using System.Linq;
using System.Net;
using NUnit.Framework;
using Tasks.Data.Models;
using Tasks.Tests.Api.Infrastructure;

namespace Tasks.Tests.Api
{
    [TestFixture]
    public class Task_Delete : WebApiIntegrationTest
    {
        [Test]
        public void DeletesTask()
        {
            // Arrange
            var person = new Person("Somebody");
            Context.Persons = new InMemoryDbSet<Person>
                {
                    person
                };
            Context.Tasks = new InMemoryDbSet<TaskModel>
                {
                    new TaskModel("Some task", person)
                };

            // Act
            var response = Client.DeleteAsync("http://temp.uri/api/task?responsible=Somebody&task=Some task").Result;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Accepted));
            var task = Context.Tasks.SingleOrDefault();
            Assert.That(task, Is.Null);
        }
    }
}