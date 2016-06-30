/**
 * Problem 1. Student class
 *
 * Define a class Student, which contains data about a student – first, middle and
 * last name, SSN, permanent address, mobile phone e-mail, course, specialty,
 * university, faculty. Use an enumeration for the specialties, universities
 * and faculties.
 *
 * Override the standard methods, inherited by System.Object: Equals(),
 * ToString(), GetHashCode() and operators == and !=
 *
 *
 * Problem 2. ICloneable
 *
 * Add implementations of the ICloneable interface. The Clone() method should
 * deeply copy all object's fields into a new object of type Student.
 *
 *
 * Problem 3. IComparable
 * Implement the IComparable<Student> interface to compare students by
 * names (as first criteria, in lexicographic order) and by social security
 * number (as second criteria, in increasing order).
 */
namespace Models
{
    using System;
    using Enumerations;

    public class Student : ICloneable, IComparable<Student>
    {
        public Student(string firstName, string lastName, string ssn)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.SocialSecurityNumber = ssn;
        }

        private Student()
        {
        }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string PermanentAddress { get; set; }

        public string MobilePhone { get; set; }

        public string Email { get; set; }

        public string Course { get; set; }

        public string SocialSecurityNumber { get; }

        public Specialty Specialty { get; set; }

        public University University { get; set; }

        public Faculty Faculty { get; set; }

        public static bool operator ==(Student s1, Student s2)
        {
            return s1 != null && s1.Equals(s2);
        }

        public static bool operator !=(Student s1, Student s2)
        {
            return !(s1 == s2);
        }

        public override int GetHashCode()
        {
            return this.SocialSecurityNumber.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var other = obj as Student;
            if (other == null)
            {
                return false;
            }

            return other.CompareTo(this) == 0;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}";
        }

        public object Clone()
        {
            var clone = new Student();

            foreach (var property in typeof(Student).GetProperties())
            {
                var originalValue = property.GetValue(this);
                property.SetValue(clone, originalValue);
            }

            return clone;
        }

        public int CompareTo(Student other)
        {
            var propNames = new[]
            {
                this.FirstName, this.MiddleName, this.LastName, this.SocialSecurityNumber
            };

            int result = 0;

            foreach (var propName in propNames)
            {
                var prop = typeof(Student).GetProperty(propName);
                var selfValue = (string)prop.GetValue(this);
                var otherValue = (string)prop.GetValue(other);

                result = string.Compare(selfValue, otherValue, StringComparison.Ordinal);
                if (result != 0)
                {
                    return result;
                }
            }

            return result;
        }
    }
}