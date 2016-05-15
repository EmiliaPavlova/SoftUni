namespace Abstraction.Figures
{
    using System;

    class Circle : Figure
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get { return this.radius; }
            protected set {
                if (value <= 0)
                {
                    throw  new ArgumentOutOfRangeException("Circle radius cannot be negative or zero");
                }

                this.radius = value;
            }
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalculateSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }

        public override string ToString()
        {
            string output = String.Format("Cicle with radius {0} and ", this.Radius) + base.ToString();

            return output;
        }
    }
}
