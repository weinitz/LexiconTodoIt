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
        public Todo(int todoId, String description)
        {
            this.todoId = todoId;
            this.description = description;
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