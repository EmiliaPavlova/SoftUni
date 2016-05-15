namespace MassEffect.Engine
{
    using System;
    using System.Collections.Generic;
    using Exceptions;
    using Factories;
    using GameObjects;
    using Interfaces;

    /// <summary>
    ///     The game engine.
    /// </summary>
    public sealed class GameEngine : IGameEngine
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameEngine"/> class.
        /// </summary>
        /// <param name="commandManager">
        /// The command manager.
        /// </param>
        /// <param name="galaxy">
        /// The galaxy.
        /// </param>
        public GameEngine(ICommandManager commandManager, Galaxy galaxy)
        {
            this.CommandManager = commandManager;
            this.Galaxy = galaxy;
            this.ShipFactory = new ShipFactory();
            this.EnhancementFactory = new EnhancementFactory();
            this.Starships = new List<IStarship>();
        }

        /// <summary>
        ///     Gets or sets the enhancement factory.
        /// </summary>
        public EnhancementFactory EnhancementFactory { get; set; }

        /// <summary>
        ///     Gets the ship factory.
        /// </summary>
        public ShipFactory ShipFactory { get; private set; }

        /// <summary>
        ///     Gets the starships.
        /// </summary>
        public IList<IStarship> Starships { get; private set; }

        /// <summary>
        ///     Gets the galaxy.
        /// </summary>
        public Galaxy Galaxy { get; private set; }

        /// <summary>
        ///     Gets or sets the command manager.
        /// </summary>
        public ICommandManager CommandManager { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether is running.
        /// </summary>
        public bool IsRunning { get; set; }

        /// <summary>
        ///     The run.
        /// </summary>
        public void Run()
        {
            this.IsRunning = true;
            this.CommandManager.Engine = this;
            this.CommandManager.SeedCommands();

            do
            {
                string command = Console.ReadLine();

                try
                {
                    this.CommandManager.ProcessCommand(command);
                }
                catch (ShipException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
 while (this.IsRunning);
        }
    }
}