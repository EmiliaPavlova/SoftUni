using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Point3D;

namespace Task2.DistanceCalculator
{
    public static class DistanceCalculator
    {
        public static double Distance(Point3D pointA, Point3D pointB)
        {
            double deltaX = pointA.X - pointB.X;
            double deltaY = pointA.Y - pointB.Y;
            double deltaZ = pointA.Z - pointB.Z;

            double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);

            return distance;
        }
    }
}
