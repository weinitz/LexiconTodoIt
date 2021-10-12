using System;
using System.Linq;
using TodoIt.Model;

namespace LexiconTodoIt.Data
{
    public class People
    {
        private static Person[] persons = new Person[0];

        public int Size()
        {
            return persons.Length;
        }

        public Person[] FindAll()
        {
            return persons;
        }

        public Person FindById(int personId)
        {
            var person = persons.First(e => e.PersonId == personId);
            return person;
        }

        public Person AddPerson(string firstName, string lastName)
        {
            var personId = PersonSequencer.nextPersonId();
            var person = new Person(personId, firstName, lastName);

            Array.Resize(ref persons, persons.Length + 1);

            persons[^1] = person;

            return person;
        }

        public void Clear()
        {
            persons = Array.Empty<Person>();
        }

        public void RemovePerson(Person person)
        {
            var personIndex = IndexOfPerson(person);
            persons = persons.Where((x, index) => !index.Equals(personIndex)).ToArray();
        }

        public int IndexOfPerson(Person person)
        {
            var personIndex = Array.FindIndex(persons, x => x.PersonId.Equals(person.PersonId));
            
            if (personIndex == -1) throw new ArgumentOutOfRangeException();

            return personIndex;
        }
    }
}