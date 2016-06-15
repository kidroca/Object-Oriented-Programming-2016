namespace Telerik.Homeworks.OOP.Principles
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class School
    {
        private List<Class> classes;

        private string name;

        public School(string name)
        {
            this.Name = name;
            this.classes = new List<Class>();
            this.Classes = this.classes.AsReadOnly();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                string name = Validator.ValidateName(value);
                this.Name = name;
            }
        }

        public ReadOnlyCollection<Class> Classes { get; private set; }
    }
}
