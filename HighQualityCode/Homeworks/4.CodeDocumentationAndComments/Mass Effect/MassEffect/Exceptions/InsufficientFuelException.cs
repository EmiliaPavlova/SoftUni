namespace MassEffect.Exceptions
{
    /// <summary>
    ///     The insufficient fuel exception.
    /// </summary>
    public class InsufficientFuelException : ShipException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InsufficientFuelException"/> class.
        /// </summary>
        /// <param name="msg">
        /// The msg.
        /// </param>
        public InsufficientFuelException(string msg)
            : base(msg)
        {
        }
    }
}