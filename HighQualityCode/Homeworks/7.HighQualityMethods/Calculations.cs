namespace Methods
{
    using System;

    public static class Calculations
    {
        /// <summary>
        /// Calculation of the triangle area
        /// </summary>
        /// <param name="a">triangle side a</param>
        /// <param name="b">triangle side b</param>
        /// <param name="c">triangle side c</param>
        /// <returns>the <see cref="double"/></returns>
        /// <exception cref="ArgumentException">Sides should be positive numbers bigger than 0.</exception>
        public static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("All sides should be positive.");
            }

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

            return area;
        }

        /// <summary>
        /// Finds the array max value.
        /// </summary>
        /// <param name="elements">Array elements</param>
        /// <returns>the <see cref="int"/></returns>
        /// <exception cref="ArgumentNullException">The input array is empty.</exception>
        public static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentNullException("elements", "The input array is empty");
            }

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > elements[0])
                {
                    elements[0] = elements[i];
                }
            }

            return elements[0];
        }

        /// <summary>
        /// Calculates distance between two points.
        /// </summary>
        /// <param name="x1">Coordinate X of first point</param>
        /// <param name="y1">Coordinate Y of first point</param>
        /// <param name="x2">Coordinate X of second point</param>
        /// <param name="y2">Coordinate Y of second point</param>
        /// <param name="isHorizontal">Checks if the line crossing the two given points is horizontal.</param>
        /// <param name="isVertical">Checks if the line crossing the two given points is vertical.</param>
        /// <returns></returns>
        public static double CalcDistance(double x1, double y1, double x2, double y2,
            out bool isHorizontal, out bool isVertical)
        {
            isHorizontal = (y1 == y2);
            isVertical = (x1 == x2);

            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }
    }
}