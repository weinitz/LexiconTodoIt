using System;
using TodoIt.Model;

namespace LexiconTodoIt.Data
{
    class People
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
            if (personId > Size())
            {
                throw new ArgumentOutOfRangeException();
            }
            return persons[personId];
        }

        public Person AddPerson(string firstName, string lastName)
        {
            var personId = PersonSequencer.nextPersonId();
            var person = new Person(personId, firstName, lastName);

            Array.Resize(ref People.persons, People.persons.Length + 1);

            People.persons[People.persons.Length] = person;

            return person;
        }

        public void Clear()
        {
            People.persons = Array.Empty<Person>();
        }
    }
}