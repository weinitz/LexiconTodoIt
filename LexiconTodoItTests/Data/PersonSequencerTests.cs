using Xunit;
using LexiconTodoIt.Data;

namespace LexiconTodoItTests
{
    public class PersonSequencerTests
    {
        [Fact]
        public void NextPersonIdTest()
        {
            var expected = 1;
            var actual = PersonSequencer.nextPersonId();

            Assert.Equal(expected, actual);
        }
    }
}
