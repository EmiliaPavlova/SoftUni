namespace MassEffect.GameObjects
{
    using Engine.Commands;
    using Interfaces;

    public class SystemReportCommand : Command
    {
        public SystemReportCommand(IGameEngine gameEngine) : base(gameEngine)
        {
        }
    }
}