namespace Abstraction.Figures
{
    public abstract class Figure : IFigure
    {
        public abstract double CalculatePerimeter();

        public abstract double CalculateSurface();

        public override string ToString()
        {
            string output = string.Format("perimeter: {0:f2}, surface: {1:f2}",
                this.CalculatePerimeter(), this.CalculateSurface());

            return output;
        }
    }
}
