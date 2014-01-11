using System;

namespace Tasks.Models
{
    public class TaskModel
    {
        public TaskModel(string task, string responsible)
        {
            if (task == null) throw new ArgumentNullException("task");
            if (responsible == null) throw new ArgumentNullException("responsible");
            Task = task;
            Responsible = responsible;
            Done = false;
        }

        public string Task { get; private set; }

        public string Responsible { get; private set; }

        public bool Done { get; private set; }

        public void SetDone(bool done)
        {
            Done = done;
        }
    }
}