using System;

namespace TodoIt.Model
{
    public class Todo
    {
        private readonly int todoId;
        private String description;
        private bool done;
        private Person assignee;
        public Todo(int todoId, String description)
        {
            this.todoId = todoId;
            this.description = description;
        }

    }
}