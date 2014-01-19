using System;

namespace Tasks.Data.Models
{
    public class TaskModel
    {
        public TaskModel(string task, Person responsible)
        {
            if (task == null) throw new ArgumentNullException("task");
            if (responsible == null) throw new ArgumentNullException("responsible");
            Task = task;
            Responsible = responsible;
            Done = false;
        }

        private TaskModel()
        {
        }

        public int Id { get; set; }

        public string Task { get; private set; }

        public Person Responsible { get; private set; }

        public int ResponsibleId { get; set; }

        public bool Done { get; private set; }

        public void SetDone(bool done)
        {
            Done = done;
        }
    }
}