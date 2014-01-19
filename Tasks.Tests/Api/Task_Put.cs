using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using NUnit.Framework;
using Tasks.Data.Models;
using Tasks.Tests.Api.Infrastructure;

namespace Tasks.Tests.Api
{
    [TestFixture]
    public class Task_Put : WebApiIntegrationTest
    {
        [Test]
        public void UpdatesExistingTask()
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
            var request = new
                {
                    responsible = "Somebody",
                    task = "Some task",
                    done = true
                };
            var response = Client.PutAsJsonAsync("http://temp.uri/api/task", request).Result;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Accepted));
            var task = Context.Tasks.SingleOrDefault();
            Assert.That(task, Is.Not.Null);
            Debug.Assert(task != null, "task != null");
            Assert.That(task.Responsible.Name, Is.EqualTo("Somebody"));
            Assert.That(task.Task, Is.EqualTo("Some task"));
            Assert.That(task.Done, Is.True);
        }
    }
}