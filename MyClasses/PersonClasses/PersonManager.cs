using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClasses.PersonClasses
{
    public class PersonManager
    {
        public Person CreatePerson(string firstName, string lastName, bool isSupervisor)
        {
            Person ret = null;

            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                if (isSupervisor)
                {
                    ret = new Supervisor();
                }
                else
                {
                    ret = new Employee();
                }
                ret.FirstName = firstName;
                ret.LastName = lastName;
            }
            return ret;
        }

        public List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();

            people.Add(new Person() { FirstName = "Fernando", LastName = "Leme" });
            people.Add(new Person() { FirstName = "Daiana", LastName = "Leme" });
            people.Add(new Person() { FirstName = "Runa", LastName = "Leme" });

            return people;
        }

        public List<Person> GetSupervisors()
        {
            List<Person> people = new List<Person>();
            people.Add(CreatePerson("Fernando", "Leme", true));
            people.Add(CreatePerson("Daiana", "Leme", true));

            return people;
        }
    }
}
