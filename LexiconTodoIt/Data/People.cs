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
            var person = persons.First((e) => e.PersonId == personId);
            return person;
        }

        public Person AddPerson(string firstName, string lastName)
        {
            var personId = PersonSequencer.nextPersonId();
            var person = new Person(personId, firstName, lastName);

            Array.Resize(ref People.persons, People.persons.Length + 1);

            People.persons[Size()-1] = person;

            return person;
        }

        public void Clear()
        {
            People.persons = Array.Empty<Person>();
        }
    }
}