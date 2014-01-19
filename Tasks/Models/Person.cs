using System;

namespace Tasks.Models
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

        public string Name { get; set; }
    }
}