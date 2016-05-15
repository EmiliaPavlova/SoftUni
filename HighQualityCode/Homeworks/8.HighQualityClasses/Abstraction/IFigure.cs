namespace Abstraction
{
    public interface IFigure
    {
        /// <summary>
        /// Calculate figure perimeter
        /// </summary>
        /// <returns><see cref="double"/></returns>
        double CalculatePerimeter();

        /// <summary>
        /// Calculate figure surface
        /// </summary>
        /// <returns><see cref="double"/></returns>
        double CalculateSurface();
    }
}