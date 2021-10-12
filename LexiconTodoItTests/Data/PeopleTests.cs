using System;
using LexiconTodoIt.Data;
using Xunit;

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
            PersonSequencer.Reset();
            people.Clear();
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

            var people = new People();
            PersonSequencer.Reset();
            people.Clear();

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

            var people = new People();
            PersonSequencer.Reset();
            people.Clear();

            var person = people.AddPerson(firstName, lastName);

            var foundPerson = people.FindById(person.PersonId);

            Assert.Equal(person.PersonId, foundPerson.PersonId);
        }

        [Fact]
        public void RemovePersonTest()
        {
            var firstName = "Tim";
            var lastName = "Weinitz";

            var people = new People();
            PersonSequencer.Reset();
            people.Clear();

            var person = people.AddPerson(firstName, lastName);

            people.RemovePerson(person);

            person = people.AddPerson(firstName, lastName);

            Assert.Equal(1, people.Size());
            Assert.Equal(2, person.PersonId);
        }

        [Fact]
        public void IndexOfPersonTest()
        {
            const string firstName = "Tim";
            const string lastName = "Weinitz";

            var people = new People();
            PersonSequencer.Reset();
            people.Clear();

            var persons = new[]
                        {
                            people.AddPerson(firstName, lastName),
                            people.AddPerson(firstName, lastName),
                            people.AddPerson(firstName, lastName)
                        };
            people.RemovePerson(persons[1]);
            Assert.Equal(0, people.IndexOfPerson(persons[0]));
            Assert.Equal(1, people.IndexOfPerson(persons[2]));
            Assert.Throws<ArgumentOutOfRangeException>(() => people.IndexOfPerson(persons[1]));
        }
    }
}
