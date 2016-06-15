namespace Telerik.Homeworks.OOP.Principles
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class Class
    {
        private uint nextStudentNumber = 1;

        private List<Student> students;

        private List<Teacher> teachers;

        public Class()
        {
            this.students = new List<Student>();
            this.Students = this.students.AsReadOnly();

            this.teachers = new List<Teacher>();
            this.Teachers = this.teachers.AsReadOnly();
        }

        public Class(List<Student> students, List<Teacher> teachers)
        {
            this.students = students;
            this.students.ForEach(s => s.AssignClassNumber(this.nextStudentNumber++));
            this.Students = this.students.AsReadOnly();

            this.teachers = teachers;
            this.Teachers = this.teachers.AsReadOnly();
        }

        public string Identifier { get; private set; }

        public ReadOnlyCollection<Student> Students { get; private set; }

        public ReadOnlyCollection<Teacher> Teachers { get; private set; }

        public Comment Comment { get; set; }

        public void AddStudent(Student student)
        {
            student.AssignClassNumber(this.nextStudentNumber++);
            this.students.Add(student);
        }

        public void AddStudents(List<Student> students)
        {
            students.ForEach(s => this.AddStudent(s));
        }

        public Student RemoveStudent(uint number)
        {
            int index = this.students.FindIndex(s => s.ClassNumber == number);

            if (index == -1)
            {
                throw new ArgumentException("No student found with the given class number");
            }

            var student = this.students[index];
            this.students.RemoveAt(index);

            return student;
        }
    }
}
