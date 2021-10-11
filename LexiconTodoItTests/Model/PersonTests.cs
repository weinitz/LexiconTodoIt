using System;
using TodoIt.Model;
using Xunit;

namespace LexiconTodoItTests
{
    public class PersonTests
    {
        [Fact]
        public void ConstructorTests()
        {
            const int personId = 1;
            const string firstName = "Tim";
            const string lastName = "Weinitz";
            var person = new Person(personId, firstName, lastName);
            Assert.Equal(personId, person.PersonId);
            Assert.Equal(firstName, person.FirstName);
            Assert.Equal(lastName, person.LastName);
        }

        [Fact]
        public void ConstructorEmptyName()
        {
            const int personId = 1;
            const string firstName = "";
            const string lastName = " ";

            Assert.Throws<ArgumentNullException>(
                () => new Person(personId, firstName, lastName)
            );
        }
    }
}