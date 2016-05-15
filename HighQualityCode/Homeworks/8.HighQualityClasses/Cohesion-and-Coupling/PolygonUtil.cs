namespace CohesionAndCoupling
{
    using System;

    /// <summary>
    /// Holds Distance calculation in 2D and 3D coordinate system
    /// </summary>
    public class PolygonUtil
    {
        /// <summary>
        /// Returns the distance between two points in 2D coordinate system
        /// </summary>
        /// <param name="x1">coordinate X of point A</param>
        /// <param name="y1">coordinate Y of point A</param>
        /// <param name="x2">coordinate X of point B</param>
        /// <param name="y2">coordinate Y of point B</param>
        /// <returns><see cref="double"/></returns>
        public static double CalcDistance2D(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        /// <summary>
        /// Returns the distance between two points in 3D coordinate system
        /// </summary>
        /// <param name="x1">coordinate X of point A</param>
        /// <param name="y1">coordinate Y of point A</param>
        /// <param name="z1">coordinate Z of point A</param>
        /// <param name="x2">coordinate X of point B</param>
        /// <param name="y2">coordinate Y of point B</param>
        /// <param name="z2">coordinate Z of point B</param>
        /// <returns><see cref="double"/></returns>
        public static double CalcDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1));
            return distance;
        }
    }
}