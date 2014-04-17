using System;

namespace Tasks.Data.Models
{
    public class Person
    {
        public Person(string name)
        {
            if (name == null) throw new ArgumentNullException("name");
            Name = name;
        }

        private Person()
        {
        }

        public int Id { get; set; }

        public string Name { get; private set; }

        public TaskModel AddTask(string task)
        {
            if (task == null) throw new ArgumentNullException("task");
            return new TaskModel(task, this);
        }
    }
}