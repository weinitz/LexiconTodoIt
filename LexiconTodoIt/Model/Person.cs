using System;

namespace TodoIt.Model
{
    public class Person
    {
        private readonly int personId;

        private string firstName;

        private string lastName;

        public Person(int personId, string firstName, string lastName)
        {
            this.personId = personId;
            FirstName = firstName;
            LastName = lastName;
        }

        public int PersonId => personId;

        public string FirstName
        {
            get => firstName;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException();

                firstName = value;
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException();

                lastName = value;
            }
        }
    }
}