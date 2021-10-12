using LexiconTodoIt.Data;
using TodoIt.Model;
using Xunit;

namespace LexiconTodoItTests
{
    public class PeopleTests
    {
        People SetupPeople()
        {
            var people = new People();
            people.Clear();
            PersonSequencer.Reset();
            return people;
        }

        [Fact]
        public void AddPersonTest()
        {
            var firstName = "Tim";
            var lastName = "Weinitz";

            var people = SetupPeople();
            var person = people.AddPerson(firstName, lastName);

            Assert.Equal(firstName, person.FirstName);
            Assert.Equal(lastName, person.LastName);
            Assert.Equal(1, people.Size());
        }

        [Fact]
        public void ClearTest()
        {
            var firstName = "Tim";
            var lastName = "Weinitz";

            var people = SetupPeople();

            people.AddPerson(firstName, lastName);

            Assert.Equal(1, people.Size());
            people.Clear();
            Assert.Equal(0, people.Size());
        }

        [Fact]
        public void FindByIdTest()
        {
            var firstName = "Tim";
            var lastName = "Weinitz";

            var people = SetupPeople();
            var person = people.AddPerson(firstName, lastName);
            var foundPerson = people.FindById(person.PersonId);

            Assert.Equal(person.PersonId, foundPerson.PersonId);
        }

        [Fact]
        public void RemovePersonTest()
        {
            var firstName = "Tim";
            var lastName = "Weinitz";

            var people = SetupPeople();

            var person1 = people.AddPerson(firstName, lastName);
            var successfullyRemovedPerson = people.RemovePerson(person1);

            var person2 = new Person(12, firstName, lastName);
            var successfullyRemovedNotPresentPerson = people.RemovePerson(person2);

            Assert.True(successfullyRemovedPerson);
            Assert.False(successfullyRemovedNotPresentPerson);
        }

        [Fact]
        public void IndexOfPersonTest()
        {
            const string firstName = "Tim";
            const string lastName = "Weinitz";

            var people = SetupPeople();

            var persons = new[]
            {
                people.AddPerson(firstName, lastName),
                people.AddPerson(firstName, lastName),
                people.AddPerson(firstName, lastName)
            };
            people.RemovePerson(persons[1]);
            Assert.Equal(0, people.IndexOfPerson(persons[0]));
            Assert.Equal(1, people.IndexOfPerson(persons[2]));
            Assert.Equal(-1, people.IndexOfPerson(persons[1]));
        }
    }
}