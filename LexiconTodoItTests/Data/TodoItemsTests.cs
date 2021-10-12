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
            todoItems = new TodoItems();
            people = new People();
        }
        [Fact]
        public void AddNewTodo()
        {
            Setup();
            var todo = todoItems.AddTodo("Something");
            Assert.Single(todoItems.FindAll());
            Assert.Equal(todo , todoItems.FindAll()[0]);
        }

    }
}