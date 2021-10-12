using System;
using System.Linq;
using TodoIt.Model;

namespace LexiconTodoIt.Data
{

    /// <summary>
    /// Repository of persons
    /// </summary>
    public class People
    {

        /// <summary>
        /// Array of persons
        /// </summary>
        private static Person[] persons = new Person[0];

        /// <summary>
        /// Number of items in persons
        /// </summary>
        /// <returns>The total size of persons</returns>
        public int Size()
        {
            return persons.Length;
        }

        /// <summary>
        /// Find all elements in persons
        /// </summary>
        /// <returns>all persons</returns>
        public Person[] FindAll()
        {
            return persons;
        }

        /// <summary>
        /// Searches for an person that matches the ><paramref name="personId" />, and returns the first occurrence in persons" />.
        /// </summary>
        /// <param name="personId">The personId to be found</param>
        /// <returns>The found person</returns>
        public Person FindById(int personId)
        {
            
            var person = persons.First(e => e.PersonId == personId);
            return person;
        }

        /// <summary>
        /// Adds a person to persons.
        /// </summary>
        /// <param name="firstName">The first name of the person</param>
        /// <param name="lastName">The last name of the person</param>
        /// <returns>The added person</returns>
        public Person AddPerson(string firstName, string lastName)
        {
            var personId = PersonSequencer.nextPersonId();
            var person = new Person(personId, firstName, lastName);

            Array.Resize(ref persons, persons.Length + 1);

            persons[^1] = person;

            return person;
        }

        /// <summary>
        /// Clear persons
        /// </summary>
        public void Clear()
        {
            persons = Array.Empty<Person>();
        }

        /// <summary>Removes the a person based on the index.</summary>
        /// <param name="person">The person to remove.</param>
        public void RemovePerson(Person person)
        {
            var personIndex = IndexOfPerson(person);
            persons = persons.Where((x, index) => !index.Equals(personIndex)).ToArray();
        }

        /// <summary>
        /// Searches for person, and returns the zero-based index of the first occurrence in persons .
        /// </summary>
        /// <param name="person">The person to find PersonId for</param>
        /// <returns>The zero-based index of the first occurrence of a person that matches the PersonId, if found.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="person" /> is not found</exception>
        public int IndexOfPerson(Person person)
        {
            var personIndex = Array.FindIndex(persons, x => x.PersonId.Equals(person.PersonId));
            
            if (personIndex == -1) throw new ArgumentOutOfRangeException();

            return personIndex;
        }
    }
}