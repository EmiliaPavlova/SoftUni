namespace Abstraction.Figures
{
    using System;

    public class Rectangle : Figure
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public virtual double Width
        {
            get { return this.width; }
            private set {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Rectangle width cannot be negative or zero");
                }

                this.width = value;
            }
        }

        public virtual double Height
        {
            get { return this.height; }
            private set {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Rectangle height cannot be negative or zero");
                }

                this.height = value;
            }
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public override double CalculateSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }

        public override string ToString()
        {
            string output = String.Format("Rectangle with Width {0}, Height {1} and ", this.Width, this.Height) + base.ToString();

            return output;
        }
    }
}
