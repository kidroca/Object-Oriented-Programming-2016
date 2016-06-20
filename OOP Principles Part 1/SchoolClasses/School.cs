namespace Telerik.Homeworks.OOP.Principles
{
    using System.Collections.Generic;

    public class School
    {
        private string name;

        public School(string name)
        {
            this.Name = name;
            this.Classes = new List<ShoolClass>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = Validator.Validator.ValidateName(value);
            }
        }

        public IList<ShoolClass> Classes { get; private set; }
    }
}
