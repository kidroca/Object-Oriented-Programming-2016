namespace DefiningClassesHomework.EuclidianSpance.Models
{
    using System;
    using System.Collections.Generic;
    using Contracts;

    /// <summary>
    /// Problem 4. Path
    /// Create a class Path to hold a sequence of points in the 3D space.
    /// </summary>
    [Serializable]
    public class Path : IPath
    {
        private readonly Stack<IPoint3D> pointsInPath;

        public Path()
        {
            this.pointsInPath = new Stack<IPoint3D>();
        }

        public Path(params IPoint3D[] list)
            : this()
        {
            foreach (var point in list)
            {
                this.AddPoint(point);
            }
        }

        public IEnumerable<IPoint3D> PointsInPath => this.pointsInPath;

        public void AddPoint(IPoint3D point)
        {
            if (point == null)
            {
                throw new ArgumentException("Invalid point object");
            }

            this.pointsInPath.Push(point);
        }

        public IPoint3D RemoveLastPoint()
        {
            var point = this.pointsInPath.Pop();
            return point;
        }
    }
}
