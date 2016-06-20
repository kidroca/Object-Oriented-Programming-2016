namespace Telerik.Homeworks.OOP.Principles
{
    public class Student : Human
    {

        private uint grade;

        public Student(string fname, string lname)
            : base(fname, lname)
        {
        }

        public Student(string fname, string lname, uint grade)
            : this(fname, lname)
        {
            this.Grade = grade;
        }

        public uint Grade
        {
            get
            {
                return this.grade;
            }

            set
            {
                // validate
                this.grade = value;
            }
        }

        public override string ToString()
        {
            return string.Format(base.ToString() + "\r\nGrade: {0}", this.Grade);
        }
    }
}
