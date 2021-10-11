using LexiconTodoIt.Data;
using TodoIt.Model;
using Xunit;

namespace LexiconTodoItTests
{
    public class TodoItemsTests
    {
        private TodoItems todoItems;
        [Fact]
        public void AddNewTodo()
        {
            todoItems = new TodoItems();
            var todo = todoItems.AddTodo("Something");
            Assert.Single(todoItems.FindAll());
            Assert.Equal(todo , todoItems.FindAll()[0]);
        }

    }
}