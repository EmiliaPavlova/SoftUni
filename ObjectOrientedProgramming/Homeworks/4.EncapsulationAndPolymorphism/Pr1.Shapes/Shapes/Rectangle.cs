using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr1.Shapes
{
    class Rectangle : BasicShape
    {
        public Rectangle(double width, double height) 
            : base(width, height)
        {
        }

        public override double CalculateArea()
        {
            double area = this.Width*this.Height;
            return area;
        }

        public override double CalculatePerimeter()
        {
            double perimeter = this.Width*2 + this.Height*2;
            return perimeter;
        }
    }
}
