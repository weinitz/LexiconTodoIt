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

        public Todo[] FindByDoneStatus(bool doneStatus)
        {
            var result = todos.Where(todo => todo.Done == doneStatus);
            return result.ToArray();
        }

        public Todo[] FindByAssignee(Person assignee)
        {
            var result = todos.Where(todo => todo.Assignee.PersonId == assignee.PersonId);
            return result.ToArray();
        }
        
        public Todo[] FindUnassignedTodoItems()
        {
            var result = todos.Where(todo => todo.Assignee == null);
            return result.ToArray();
        }
        
        public Todo[] FindByAssignee(int personId)
        {
            var result = todos.Where(todo => todo.Assignee.PersonId == personId);
            return result.ToArray();
        }

        public bool RemoveTodo(Todo todo)
        {
            if (todo == null) return false;
            
            for (int i = 0; i < Size(); i++)
            {
                var t = todos[i];
                if (t.Equals(todo))
                {
                    todos = todos.Where((element, index) => index != i ).ToArray();
                    return true;
                }
            }
            return false;
        }
        
        public void Clear()
        {
            todos = Array.Empty<Todo>();
        }
    }
}