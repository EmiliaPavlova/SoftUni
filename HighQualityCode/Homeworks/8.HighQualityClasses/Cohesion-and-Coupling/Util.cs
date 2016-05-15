using System;

namespace CohesionAndCoupling
{
    public class Util
    {
        private double width;
        private double height;
        private double depth;

        public Util(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        public double Width
        {
            get { return this.width; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Width cannot be negative or zero");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get { return this.height; }
            set {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Height cannot be negative or zero");
                }

                this.height = value;
            }
        }

        public double Depth
        {
            get { return this.depth; }
            set {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Depth cannot be negative or zero");
                }

                this.depth = value;
            }
        }

        public double CalculateVolume()
        {
            double volume = Width * Height * Depth;
            return volume;
        }

        public double CalcDiagonalXYZ()
        {
            double distance = PolygonUtil.CalcDistance3D(0, 0, 0, Width, Height, Depth);
            return distance;
        }

        public double CalcDiagonalXY()
        {
            double distance = PolygonUtil.CalcDistance2D(0, 0, Width, Height);
            return distance;
        }

        public double CalcDiagonalXZ()
        {
            double distance = PolygonUtil.CalcDistance2D(0, 0, Width, Depth);
            return distance;
        }

        public double CalcDiagonalYZ()
        {
            double distance = PolygonUtil.CalcDistance2D(0, 0, Height, Depth);
            return distance;
        }
    }
}
