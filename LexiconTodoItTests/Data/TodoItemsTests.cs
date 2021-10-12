using LexiconTodoIt.Data;
using TodoIt.Model;
using Xunit;

namespace LexiconTodoItTests
{
    public class TodoItemsTests
    {
        private TodoItems todoItems;
        private People people;

        void Setup()
        {
            people = new People();
            todoItems = new TodoItems();
            todoItems.Clear();
            people.Clear();
        }
        
        [Fact]
        public void AddNewTodo()
        {
            Setup();
            var todo = todoItems.AddTodo("Something");
            Assert.Single(todoItems.FindAll());
            Assert.Equal(todo , todoItems.FindAll()[0]);
        }

        [Fact]
        public void RemoveAExistingTodoReturnsTrue()
        {
            Setup();
            var todo = todoItems.AddTodo("Some Important Task");
            var success = todoItems.RemoveTodo(todo);
            Assert.True(success);
            Assert.Equal(0,todoItems.Size());
        }
        
        [Fact]
        public void RemoveANonExistentTodoReturnsFalse()
        {
            Setup();
            todoItems.AddTodo("Some Important Task");
            // does not exist in todoItems array
            var nonExistentTodo = new Todo(TodoSequencer.nextTodoId(), "Non existent todo");
            var success = todoItems.RemoveTodo(nonExistentTodo);
            Assert.False(success);
            Assert.Equal(1,todoItems.Size());
        }

        [Fact]
        public void FindAllTodosByAssignee()
        {
            Setup();
            var michael = people.AddPerson("Michael", "Sjögren");
            var tim = people.AddPerson("Tim", "Weinitz");
            var todo1 = todoItems.AddTodo("Tim task!");
            var todo2 = todoItems.AddTodo("Michael task!");
            var todo3 = todoItems.AddTodo("Michael task 2!");

            todo2.Assignee = michael;
            todo3.Assignee = michael;
            todo1.Assignee = tim;
            Assert.Equal(2 , todoItems.FindByAssignee(michael).Length);
            Assert.Single(todoItems.FindByAssignee(tim));
        }

    }
}