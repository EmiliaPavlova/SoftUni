// --------------------------------------------------------------------------------------------------------------------
namespace MassEffect.Engine.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Interfaces;

    /// <summary>
    /// The system report command.
    /// </summary>
    public class SystemReportCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SystemReportCommand"/> class.
        /// </summary>
        /// <param name="gameEngine">
        /// The game engine.
        /// </param>
        public SystemReportCommand(IGameEngine gameEngine)
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
            string locationName = commandArgs[1];

            var starships = this.GameEngine.Starships
                .Where(s => s.Location.Name == locationName);

            IEnumerable<IStarship> intactShips =
                starships
                    .Where(s => s.Health > 0)
                    .OrderByDescending(s => s.Health)
                    .ThenByDescending(s => s.Shields);

            IEnumerable<IStarship> destroyedShips =
                starships
                    .Where(s => s.Health <= 0)
                    .OrderBy(s => s.Name);

            StringBuilder output = new StringBuilder();
            output.AppendLine("Intact ships:");
            output.AppendLine(intactShips.Any() ? string.Join("\n", intactShips) : "N/A");
            output.AppendLine("Destroyed ships:");
            output.Append(destroyedShips.Any() ? string.Join("\n", destroyedShips) : "N/A");

            Console.WriteLine(output.ToString());
        }
    }
}