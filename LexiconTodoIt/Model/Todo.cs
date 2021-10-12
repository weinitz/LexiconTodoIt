using System;

namespace TodoIt.Model
{
    public class Todo
    {
        private readonly int todoId;
        private String description;
        private bool done;
        private Person assignee;
        public int TodoId => todoId;
        public bool Done { get; set; }
        public Todo(int todoId, String description)
        {
            this.done = false;
            this.todoId = todoId;
            this.Description = description;
        }

        public Person Assignee
        {
            get => assignee;
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Assigned person was null");
                }
                assignee = value;
            }
        } 
        public string Description
        {
            get => description;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException();

                description = value;
            }
        }
    }
}