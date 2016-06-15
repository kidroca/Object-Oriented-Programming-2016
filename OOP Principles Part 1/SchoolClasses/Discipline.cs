namespace Telerik.Homeworks.OOP.Principles
{
    public class Discipline
    {
        private string name;

        private uint numberOfLectures;

        private uint numberOfExercises;

        public Discipline(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                Validator.ValidateName(value);

                this.name = value;
            }
        }

        public Comment Comment { get; set; }

    }
}
