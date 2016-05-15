namespace BoatRacingSimulator.Interfaces
{
    using System.Collections.Generic;
    using Models;
    using Models.Boats;

    /// <summary>
    /// holds public properties and a method for the Race class
    /// </summary>
    public interface IRace
    {
        /// <summary>
        /// the distance of the race
        /// </summary>
        int Distance { get; }

        /// <summary>
        /// the wind speed that affects sail boats
        /// </summary>
        int WindSpeed { get; }

        /// <summary>
        /// the speed that comes from the ocean movement
        /// </summary>
        int OceanCurrentSpeed { get; }

        /// <summary>
        /// property that signifies if motor boats are allowed in the race
        /// </summary>
        bool AllowsMotorboats { get; }

        /// <summary>
        /// a method for adding participants in the race
        /// </summary>
        /// <param name="boat">the boats that are enrolled in the race</param>
        void AddParticipant(Boat boat);

        /// <summary>
        /// a list of all participating boats
        /// </summary>
        /// <returns>returns a collection of all participants in the race</returns>
        IList<Boat> GetParticipants();
    }
}
