using System;
using TodoIt.Model;
using Xunit;

namespace LexiconTodoItTests
{
    public class TodoTests
    {
        private Todo todo;
        
        [Fact]
        public void TestCreate()
        {
            todo = new Todo(-1, "Something");
            Assert.NotNull(todo);
            Assert.False(todo.Done);
            Assert.Null(todo.Assignee);
        }

        [Fact]
        public void EmptyDescriptionThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new Todo(-1, ""));
        }
    }
}