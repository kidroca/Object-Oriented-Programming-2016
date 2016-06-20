namespace Telerik.Homeworks.OOP.Principles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Human
    {
        private string firstName;

        private string lastName;

        public Human(string fname, string lname)
        {
            this.FirstName = fname;
            this.LastName = lname;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            protected set
            {
                string name = Validator.ValidateName(value);

                this.firstName = name;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            protected set
            {
                string name = Validator.ValidateName(value);

                this.lastName = name;
            }
        }

        public override string ToString()
        {
            return string.Format("First Name: '{0}' \r\nLastName: '{1}'", this.FirstName, this.LastName);
        }
    }
}
