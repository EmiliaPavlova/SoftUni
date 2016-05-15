namespace MassEffect.Engine.Commands
{
    using System;
    using Interfaces;

    /// <summary>
    /// The status report command.
    /// </summary>
    public class StatusReportCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StatusReportCommand"/> class.
        /// </summary>
        /// <param name="gameEngine">
        /// The game engine.
        /// </param>
        public StatusReportCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="commandArgs">
        /// The command args.
        /// </param>
        public override void Execute(string[] commandArgs)
        {
            string shipName = commandArgs[1];
            IStarship ship = this.GetStarshipByName(shipName);

            Console.WriteLine(ship.ToString());
        }
    }
}