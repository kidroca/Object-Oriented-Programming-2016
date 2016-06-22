namespace Telerik.Homeworks.OOP.Principles.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class AnimalProgram
    {
        private static void Main()
        {
            var animals = new List<Animal>()
            {
                new Dog("Pesho", Gender.Male, 12),
                new Kitten("Petia", 11),
                new Tomcat("Petko", 5),
                new Frog("Petra", Gender.Female, 3),
                new Dog("Penio", Gender.Male, 23),
                new Kitten("Paca", 3),
                new Tomcat("Paco", 6),
                new Frog("Panko", Gender.Male, 5),
                new Dog("Penka", Gender.Female, 10),
                new Kitten("Peruna", 4),
                new Tomcat("Pencho", 6),
                new Frog("Petar", Gender.Male, 2)
            };

            PrintAnimals(animals);

            var averageAges = GetAverageAges(animals);

            foreach (var key in averageAges.Keys)
            {
                Console.WriteLine($"{key} average age: {averageAges[key] :F}");
            }
        }

        private static IDictionary<string, double> GetAverageAges(IEnumerable<Animal> animals)
        {
            var results = animals
                .GroupBy(a => a.GetType().Name)
                .ToDictionary(
                    grouping => grouping.Key,
                    grouping => grouping.Average(animal => animal.Age));

            return results;
        }

        private static void PrintAnimals(IEnumerable<Animal> animals)
        {
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.Speak());
                Console.WriteLine(new string('-', 50));
            }
        }
    }
}
