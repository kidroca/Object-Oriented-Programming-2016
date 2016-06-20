namespace Telerik.Homeworks.OOP.Principles
{
    public class Student : Person
    {
        public Student(string fname, string lname)
            : base(fname, lname)
        {
        }

        public Comment Comment { get; set; }

        public uint ClassNumber { get; private set; }

        public void AssignClassNumber(uint number)
        {
            this.ClassNumber = number;
        }
    }
}
