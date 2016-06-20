namespace Telerik.Homeworks.OOP.Principles
{
    public abstract class Human
    {
        private string firstName;

        private string lastName;

        protected Human(string fname, string lname)
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

            private set
            {
                string name = Validator.Validator.ValidateName(value);

                this.firstName = name;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                string name = Validator.Validator.ValidateName(value);

                this.lastName = name;
            }
        }

        public override string ToString()
        {
            return $"First Name: '{this.FirstName}' \r\nLastName: '{this.LastName}'";
        }
    }
}
