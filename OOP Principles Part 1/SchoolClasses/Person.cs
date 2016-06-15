namespace Telerik.Homeworks.OOP.Principles
{
    public abstract class Person
    {
        private string firstName;

        private string lastName;

        public Person(string fname, string lname)
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
    }
}
