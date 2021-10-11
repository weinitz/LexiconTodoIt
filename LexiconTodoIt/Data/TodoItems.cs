using System;
using System.Collections.Generic;
using System.Text;
using LexiconTodoIt.Model;
using TodoIt.Model;

namespace LexiconTodoIt.Data
{
    class TodoItems
    {
        private static Todo[] todos = new Todo[0];

        public int Size()
        {
            return todos.Length;
        }

        public Todo[] FindAll()
        {
            return todos;
        }

        public Todo FindById(int todoId)
        {
            if (todoId > Size())
            {
                throw new ArgumentOutOfRangeException();
            }
            return todos[todoId];
        }

        public Todo AddTodo(string description)
        {
            var todoId = PersonSequencer.nextPersonId();
            var todo = new Todo(todoId, description);

            Array.Resize(ref TodoItems.todos, TodoItems.todos.Length + 1);

            TodoItems.todos[TodoItems.todos.Length] = todo;

            return todo;
        }

        public void Clear()
        {
            TodoItems.todos = Array.Empty<Todo>();
        }
    }
}
