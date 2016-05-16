using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr1.Shapes
{
    internal class Rhombus : BasicShape
    {
        private double sideC;

        public Rhombus(double sideA, double sideB, double sideC) 
            : base(sideA, sideB)
        {
            this.SideC = sideC;
        }

        public double SideC
        {
            get { return this.sideC; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The side cannot be negative number.");
                }
                this.sideC = value;
            }
        }

        public override double CalculateArea()
        {
            double halfPerimeter = this.CalculatePerimeter() / 2;
            double areaSquared = halfPerimeter;
            areaSquared *= halfPerimeter - this.Width;
            areaSquared *= halfPerimeter - this.Height;
            areaSquared *= halfPerimeter - this.SideC;
            double area = Math.Sqrt(areaSquared) * 2;
            return area;
        }

        public override double CalculatePerimeter()
        {
            double perimether = this.Width + this.Height + this.sideC;
            return perimether;
        }
    }
}
