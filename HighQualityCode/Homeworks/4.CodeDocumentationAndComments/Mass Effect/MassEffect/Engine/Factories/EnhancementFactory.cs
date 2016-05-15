namespace MassEffect.Engine.Factories
{
    using System;
    using GameObjects.Enhancements;

    /// <summary>
    /// The enhancement factory.
    /// </summary>
    public class EnhancementFactory
    {
        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="enhancementType">
        /// The enhancement type.
        /// </param>
        /// <returns>
        /// The <see cref="Enhancement"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Enhancement Create(EnhancementType enhancementType)
        {
            switch (enhancementType)
            {
                case EnhancementType.ThanixCannon:
                    return new Enhancement("ThanixCannon", 0, 50, 0);
                case EnhancementType.KineticBarrier:
                    return new Enhancement("KineticBarrier", 100, 0, 0);
                case EnhancementType.ExtendedFuelCells:
                    return new Enhancement("ExtendedFuelCells", 0, 0, 200);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}