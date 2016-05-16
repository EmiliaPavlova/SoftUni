namespace _1.DistanceCalculatorSOAPService
{
    using System;
    using System.Drawing;

    public class Service1 : IServiceDistanceCalc
    {
        public double CalcDistance(Point startPoint, Point endPoint)
        {
            double x = startPoint.X - endPoint.X;
            double y = startPoint.Y - endPoint.Y;

            var distance = Math.Sqrt(x * x + y * y);

            return distance;
        }
    }
}
