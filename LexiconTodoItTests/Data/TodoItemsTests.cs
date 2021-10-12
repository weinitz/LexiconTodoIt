using LexiconTodoIt.Data;
using TodoIt.Model;
using Xunit;

namespace LexiconTodoItTests
{
    public class TodoItemsTests
    {
        private TodoItems todoItems;

        void Setup()
        {
            todoItems = new TodoItems();
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

    }
}