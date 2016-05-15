namespace MassEffect.Engine.Commands
{
    using Interfaces;

    /// <summary>
    /// The over command.
    /// </summary>
    public class OverCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OverCommand"/> class.
        /// </summary>
        /// <param name="gameEngine">
        /// The game engine.
        /// </param>
        public OverCommand(IGameEngine gameEngine)
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
            this.GameEngine.IsRunning = false;
        }
    }
}