namespace Tests
{
    using System.Linq;
    using ConsoleMio.ConsoleEnhancements;
    using Models;
    using static System.ConsoleColor;

    class Program
    {
        private static readonly ConsoleMio ConsoleMio = new ConsoleMio();

        static void Main()
        {
            ConsoleMio.PrintHeading("Common Type System");

            var five = new BitArray64(5);
            ConsoleMio
                .Write("Creating new BitArray64(", DarkBlue)
                .Write(5, DarkRed)
                .WriteLine(")", DarkBlue)
                .Write("Binary Value: [", DarkBlue)
                .Write(string.Join("", five.Reverse()), DarkRed)
                .WriteLine("]", DarkBlue)
                .WriteLine();

            var pesho = new Person("Pesho");
            var gosho = new Person("Gosho", 19);

            ConsoleMio.WriteLine("Creating 2 people", DarkBlue)
                .WriteLine()
                .WriteLine(pesho, DarkRed)
                .WriteLine()
                .WriteLine(gosho, DarkRed);
        }
    }
}
