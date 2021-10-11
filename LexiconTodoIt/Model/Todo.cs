using System;
using System.Collections.Generic;
using System.Text;
using TodoIt.Model;

namespace LexiconTodoIt.Model
{
    class Todo
    {
        private readonly int todoId;
        private string description;
        private bool done;
        private Person assignee;

        public Todo(int todoId, string description)
        {
            this.todoId = todoId;
            this.description = description;
        }

    }
}
