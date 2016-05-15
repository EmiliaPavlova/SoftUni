namespace MassEffect.Engine
{
    using Commands;

    /// <summary>
    ///     The extended command manager.
    /// </summary>
    public class ExtendedCommandManager : CommandManager
    {
        /// <summary>
        ///     The seed commands.
        /// </summary>
        public override void SeedCommands()
        {
            base.SeedCommands();

            this.commandsByName["system-report"] = new SystemReportCommand(this.Engine);
        }
    }
}