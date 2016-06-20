namespace Telerik.Homeworks.OOP.Principles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StudentWorkerProgram
    {
        private static readonly Random Rnd = new Random();

        private static void Main(string[] args)
        {
            var students = new List<Student>();
            for (var i = 0; i < 10; i++)
            {
                var someGuy = new Student("Robot", "Number: " + (i + 1), (uint)Rnd.Next(1, 10));
                students.Add(someGuy);
            }

            students = students
                .OrderBy(s => s.Grade)
                .ToList();

            foreach (var s in students)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine();

            var workers = new List<Worker>();
            for (var i = 0; i < 10; i++)
            {
                var workingJoe = new Worker("Andro", "Count: " + (i + 1), Rnd.Next(15, 1000), (uint)Rnd.Next(1, 8));
                workers.Add(workingJoe);
            }

            workers = workers
                .OrderByDescending(w => w.MoneyPerHour())
                .ToList();

            foreach (var w in workers)
            {
                Console.WriteLine(w);
            }

            Console.WriteLine();

            var people = new List<Human>(students);
            people.AddRange(workers);

            people = people
                .OrderBy(p => p.FirstName)
                .ThenBy(p => p.LastName)
                .ToList();

            foreach (var p in people)
            {
                Console.WriteLine(p);
            }
        }
    }
}