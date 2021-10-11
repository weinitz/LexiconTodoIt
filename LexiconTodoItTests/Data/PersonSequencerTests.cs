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
            var actual = PersonSequencer.NextPersonId();

            Assert.Equal(expected, actual);
        }
    }
}
