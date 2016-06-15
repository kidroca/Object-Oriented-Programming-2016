namespace Telerik.Homeworks.OOP.Principles.Shapes
{
    using System;
    using System.Collections.Generic;

    public class ShapesEntryPoint
    {
        private static void Main()
        {
            var tri = new Triangle(10, 5);

            var rect = new Rectangle(6, 9.5);

            var sq = new Square(4.33);

            var figs = new List<Shape> { tri, rect, sq };

            figs.ForEach(s => Console.WriteLine(s.CalculateSurface()));
        }
    }
}
