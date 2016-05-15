namespace AirConditionerSystem.Interfaces
{
    using Models;

    /// <summary>
    /// The interface for Reports issued for air conditioners
    /// </summary>
    public interface IReport
    {
        /// <summary>
        /// the manufacturer that issue the report
        /// </summary>
        string Manufacturer { get; }

        /// <summary>
        /// the model of the air conditioner the report is issued
        /// </summary>
        string Model { get; }

        /// <summary>
        /// the result of the Test metod that determines if the air conditioner will be marked as passed or failed
        /// </summary>
        Mark Mark { get; }
    }
}