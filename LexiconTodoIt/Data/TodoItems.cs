using System;
using TodoIt.Model;
using System.Linq;
namespace LexiconTodoIt.Data
{
    public class TodoItems
    {
        private static Todo[] todos = Array.Empty<Todo>();

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
            // TODO handle when id is not found
            return todos.First((e) => e.TodoId == todoId );
        }

        public Todo AddTodo(String description)
        {
            var id = TodoSequencer.nextTodoId();
            Array.Resize(ref todos , Size()+1);
            
            // TODO validate todo item?
            var todo = new Todo(id, description);
            todos[Size() - 1] = todo;
            return todo;
        }

        public void Clear()
        {
            todos = Array.Empty<Todo>();
        }
    }
}