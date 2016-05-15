namespace MassEffect.Exceptions
{
    /// <summary>
    ///     The location out of range exception.
    /// </summary>
    public class LocationOutOfRangeException : ShipException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocationOutOfRangeException"/> class.
        /// </summary>
        /// <param name="msg">
        /// The msg.
        /// </param>
        public LocationOutOfRangeException(string msg)
            : base(msg)
        {
        }
    }
}