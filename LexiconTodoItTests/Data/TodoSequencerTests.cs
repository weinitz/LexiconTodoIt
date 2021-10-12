using System;
using LexiconTodoIt.Data;
using Xunit;
namespace LexiconTodoItTests
{
    public class TodoSequencerTests
    {
        void Setup()
        {
            TodoSequencer.reset();
        }
        
        [Fact]
        public void NextTodoId()
        {
            Setup();
            var expected = 1;
            var actual = TodoSequencer.nextTodoId();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ResetTodoIdIsZero()
        {
            Setup();
            var actual = TodoSequencer.nextTodoId();
            Assert.Equal(1, actual);
            Assert.Equal(2, TodoSequencer.nextTodoId());
            TodoSequencer.reset();
            Assert.Equal(1, TodoSequencer.nextTodoId());
        }
    }
}