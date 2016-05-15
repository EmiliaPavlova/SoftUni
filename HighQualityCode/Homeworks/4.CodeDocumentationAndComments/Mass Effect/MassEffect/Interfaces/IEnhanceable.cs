namespace MassEffect.Interfaces
{
    using System.Collections.Generic;
    using GameObjects.Enhancements;

    /// <summary>
    ///     The Enhanceable interface.
    /// </summary>
    public interface IEnhanceable
    {
        /// <summary>
        ///     Gets the enhancements.
        /// </summary>
        IEnumerable<Enhancement> Enhancements { get; }

        /// <summary>
        /// The add enhancement.
        /// </summary>
        /// <param name="enhancement">
        /// The enhancement.
        /// </param>
        void AddEnhancement(Enhancement enhancement);
    }
}