using System.Runtime.InteropServices.ComTypes;
using LexiconTodoIt.Data;
using Xunit;
using TodoIt.Model;

namespace LexiconTodoItTests
{
    public class PeopleTests
    {
        [Fact]
        public void AddPersonTest()
        {
            var firstName = "Tim";
            var lastName = "Weinitz";

            var people = new People();
            var person = people.AddPerson(firstName, lastName);

            Assert.Equal(firstName, person.FirstName);
            Assert.Equal(lastName, person.LastName);
            Assert.Equal(1, people.Size());
            
            people.Clear();
            Assert.Equal(0, people.Size());
        }

        [Fact]
        public void FindByIdTest()
        {
            var firstName = "Tim";
            var lastName = "Weinitz";

            var people = new People();
            var person = people.AddPerson(firstName, lastName);

            var foundPerson = people.FindById(person.PersonId);

            Assert.Equal(firstName, person.FirstName);
            Assert.Equal(lastName, person.LastName);
        }
    }
}
