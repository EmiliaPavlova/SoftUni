namespace MassEffect.Engine.Commands
{
    using System.Linq;
    using Exceptions;
    using Interfaces;

    /// <summary>
    /// The command.
    /// </summary>
    public abstract class Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Command"/> class.
        /// </summary>
        /// <param name="gameEngine">
        /// The game engine.
        /// </param>
        protected Command(IGameEngine gameEngine)
        {
            this.GameEngine = gameEngine;
        }

        /// <summary>
        /// Gets or sets the game engine.
        /// </summary>
        public IGameEngine GameEngine { get; set; }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="commandArgs">
        /// The command args.
        /// </param>
        public abstract void Execute(string[] commandArgs);

        /// <summary>
        /// The get starship by name.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="IStarship"/>.
        /// </returns>
        protected IStarship GetStarshipByName(string name)
        {
            return this.GameEngine.Starships.First(s => s.Name == name);
        }

        /// <summary>
        /// The validate alive.
        /// </summary>
        /// <param name="ship">
        /// The ship.
        /// </param>
        /// <exception cref="ShipException">
        /// </exception>
        protected void ValidateAlive(IStarship ship)
        {
            if (ship.Health <= 0)
            {
                throw new ShipException(Messages.ShipDestroyed);
            }
        }
    }
}