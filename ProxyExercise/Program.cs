using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyExercise
{
    public class Person
    {
        public int Age { get; set; }

        public string Drink()
        {
            return "drinking";
        }

        public string Drive()
        {
            return "driving";
        }

        public string DrinkAndDrive()
        {
            return "driving while drunk";
        }
    }

    public class ResponsiblePerson
    {
        private Person person;
        public ResponsiblePerson(Person person)
        {
            this.person = person;
        }
        public int Age
        {
            get => person.Age;
            set => person.Age = value;
        }

        public string Drink()
        {
            if (person.Age < 18)
                return "too young";
            return "drinking";
        }

        public string Drive()
        {
            if (person.Age < 16)
                return "too young";
            return "driving";
        }

        public string DrinkAndDrive() => "dead";
    }
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person();
            person.Age = 18;
            Console.WriteLine(person.Drink());
            var responsablePerson = new ResponsiblePerson(person);
            Console.WriteLine(responsablePerson.Drink());
            Console.WriteLine(responsablePerson.Drive());
            Console.WriteLine(responsablePerson.DrinkAndDrive());
        }
    }
}
