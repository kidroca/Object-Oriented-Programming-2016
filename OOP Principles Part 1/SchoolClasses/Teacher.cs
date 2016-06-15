namespace Telerik.Homeworks.OOP.Principles
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class Teacher : Person
    {
        private List<Discipline> disciplines;

        public Teacher(string fname, string lname)
            : base(fname, lname)
        {
            this.disciplines = new List<Discipline>();
            this.Disciplines = this.disciplines.AsReadOnly();
        }

        public Teacher(string fname, string lname, List<Discipline> disciplines)
            : base(fname, lname)
        {
            this.disciplines = disciplines;
            this.Disciplines = this.disciplines.AsReadOnly();
        }

        public ReadOnlyCollection<Discipline> Disciplines { get; private set; }

        public Comment Comment { get; set; }

        public void AddDisciplines(Discipline subject)
        {
            this.disciplines.Add(subject);
        }

        public void RemoveDiscipline(string name)
        {
            int index = this.disciplines.FindIndex(d => d.Name == name);

            if (index == -1)
            {
                throw new ArgumentException("The discipline name could not be found in this teacher's Disciplines");
            }

            this.disciplines.RemoveAt(index);
        }

        public void RemoveDiscipline(Discipline subject)
        {
            bool success = this.disciplines.Remove(subject);

            if (!success)
            {
                throw new ArgumentException("The discipline could not be found in this teacher's Disciplines");
            }
        }
    }
}
