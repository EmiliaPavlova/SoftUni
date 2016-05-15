namespace MassEffect.Engine
{
    using System;
    using System.Collections.Generic;
    using Commands;
    using Interfaces;

    /// <summary>
    /// The command manager.
    /// </summary>
    public class CommandManager : ICommandManager
    {
        /// <summary>
        /// The commands by name.
        /// </summary>
        protected readonly Dictionary<string, Command> commandsByName;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandManager"/> class.
        /// </summary>
        public CommandManager()
        {
            this.commandsByName = new Dictionary<string, Command>();
        }

        /// <summary>
        /// Gets or sets the engine.
        /// </summary>
        public IGameEngine Engine { get; set; }

        /// <summary>
        /// The process command.
        /// </summary>
        /// <param name="commandString">
        /// The command string.
        /// </param>
        /// <exception cref="NotSupportedException">
        /// </exception>
        public void ProcessCommand(string commandString)
        {
            string[] commandArgs = commandString.Split(' ');
            string commandName = commandArgs[0];

            if (!this.commandsByName.ContainsKey(commandName))
            {
                throw new NotSupportedException(string.Format(
                    "Command {0} does not exist.", commandName));
            }

            var command = this.commandsByName[commandName];
            command.Execute(commandArgs);
        }

        /// <summary>
        /// The seed commands.
        /// </summary>
        public virtual void SeedCommands()
        {
            this.commandsByName["create"] = new CreateCommand(this.Engine);
            this.commandsByName["attack"] = new AttackCommand(this.Engine);
            this.commandsByName["status-report"] = new StatusReportCommand(this.Engine);
            this.commandsByName["plot-jump"] = new PlotJumpCommand(this.Engine);
            this.commandsByName["over"] = new OverCommand(this.Engine);
        }
    }
}