namespace Models
{
    public class Person
    {
        public Person(string name)
        {
            this.Name = name;
        }

        public Person(string name, int age)
            : this(name)
        {
            this.Age = age;
        }

        public string Name { get; set; }

        public int? Age { get; set; }

        public override string ToString()
        {
            var ageString = this.Age == null
                ? "Not specified"
                : ((int)this.Age).ToString("F2");

            return $"{this.Name}\nAge: {ageString}";
        }
    }
}
