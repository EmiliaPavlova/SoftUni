using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pr3.CompanyHierarchy.Interfaces;

namespace Pr3.CompanyHierarchy.People
{
    public abstract class Person : IPerson
    {
        private string id;
        private string firstName;
        private string lastName;

        public Person(string id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string Id { get; set; }

        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        public override string ToString()
        {
            string name = string.Format("My names is {0} {1} and I'm a {2}.", this.firstName, this.lastName,
                this.GetType().Name);
            return name;
        }
    }
}
