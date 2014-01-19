using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using NUnit.Framework;
using Tasks.Models;
using Tasks.Tests.Infrastructure;

namespace Tasks.Tests.Api
{
    [TestFixture]
    public class Task_Post : WebApiIntegrationTest
    {
        [Test]
        public void CreatesNewTask()
        {
            // Arrange
            Context.Persons = new InMemoryDbSet<Person>
                {
                    new Person("Somebody")
                };

            // Act
            var request = new
                {
                    responsible = "Somebody",
                    task = "Some task"
                };
            var response = Client.PostAsJsonAsync("http://temp.uri/api/task", request).Result;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            var task = Context.Tasks.SingleOrDefault();
            Assert.That(task, Is.Not.Null);
            Debug.Assert(task != null, "task != null");
            Assert.That(task.Responsible.Name, Is.EqualTo("Somebody"));
            Assert.That(task.Task, Is.EqualTo("Some task"));
        }

        [Test]
        public void ReturnsNaturalKey()
        {
            // Arrange
            Context.Persons = new InMemoryDbSet<Person>
                {
                    new Person("Somebody")
                };

            // Act
            var request = new
            {
                responsible = "Somebody",
                task = "Some task"
            };
            var response = Client.PostAsJsonAsync("http://temp.uri/api/task", request).Result;
            var expected = new
                {
                    responsible = "Somebody",
                    task = "Some task",
                    done = false
                };
            Assert.That(response.Content.ReadAsStringAsync().Result, Is.EqualTo(JsonConvert.SerializeObject(expected)));
        }
    }
}