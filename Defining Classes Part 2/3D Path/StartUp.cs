/* Problem 1. Structure (Done)*/
/* Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space.
 * Implement the ToString() to enable printing a 3D point. */

/* Problem 2. Static read-only field (Done)*/
/* Add a private static read-only field to hold the start of the coordinate system – the point O{0, 0, 0}.
 * Add a static property to return the point O. */

/* Problem 3. Static class (Done) */
/* Write a static class with a static method to calculate the distance between two points in the 3D space. */

/* Problem 4. Path (Done) */
/* Create a class Path to hold a sequence of points in the 3D space.
 * Create a static class PathStorage with static methods to save and load paths from a text file.
 * Use a file format of your choice. */

namespace DefiningClassesHomework.EuclidianSpance
{
    using System;
    using Functionality;
    using Models;

    public class StartUp
    {
        private static void Main()
        {
            var testPoint = new Point3D(12, 2, 1);
            // Console.WriteLine(testPoint);

            var destinationPoint = new Point3D(3003232, 512312374, 1);
            // Console.WriteLine(destinationPoint);

            Console.WriteLine(EuclidianSpaceMethods.DistanceBetweenPoints(testPoint, destinationPoint));

            var sampleRout = new Path(testPoint, destinationPoint);

            PathStorage.SavePath(sampleRout);

            var loadedRout = PathStorage.LoadPath();

            foreach (var point in loadedRout.PointsInPath)
            {
                Console.WriteLine(point);
            }


        }
    }
}
