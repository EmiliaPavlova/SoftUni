namespace MassEffect.Interfaces
{
    /// <summary>
    /// The CommandManager interface.
    /// </summary>
    public interface ICommandManager
    {
        /// <summary>
        /// Gets or sets the engine.
        /// </summary>
        IGameEngine Engine { get; set; }

        /// <summary>
        /// The method processing the commands received in the input.
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        void ProcessCommand(string command);

        /// <summary>
        /// Seeds the received commands to the GameEngine.
        /// </summary>
        void SeedCommands();
    }
}