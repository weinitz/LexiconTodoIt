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
            TodoSequencer.reset();
            PersonSequencer.Reset();
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

        [Fact]
        public void FindAllTodosByAssigneeId()
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
            Assert.Equal(2 , todoItems.FindByAssignee(michael.PersonId).Length);
            Assert.Single(todoItems.FindByAssignee(tim.PersonId));
        }
        [Fact]
        public void FindAllTodosByCompleteness()
        {
            Setup();
            var todo1 = todoItems.AddTodo("Tim task!");
            var todo2 = todoItems.AddTodo("Michael task!");
            var todo3 = todoItems.AddTodo("Michael task 2!");
            todo1.Done = true;
            todo2.Done = false;
            todo3.Done = true;
            Assert.Equal(2,todoItems.FindByDoneStatus(true).Length);
            Assert.Single(todoItems.FindByDoneStatus(false));
        }

        [Fact]
        public void FindAllUnAssignedTodos()
        {
            Setup();            
            var michael = people.AddPerson("Michael", "Sjögren");
            var tim = people.AddPerson("Tim", "Weinitz");
            
            var todo1 = todoItems.AddTodo("Tim task!");
            var todo2 = todoItems.AddTodo("Michael task!");
            var todo3 = todoItems.AddTodo("Michael task 2!");
            var todo4 = todoItems.AddTodo("Tim task 2!");

            todo1.Assignee = tim;
            var unAssignedTodos = todoItems.FindUnassignedTodoItems();
            Assert.Equal(3 ,unAssignedTodos.Length);
        }

    }
}