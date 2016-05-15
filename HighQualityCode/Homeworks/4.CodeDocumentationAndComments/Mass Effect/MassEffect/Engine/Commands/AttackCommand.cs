namespace MassEffect.Engine.Commands
{
    using System;
    using Exceptions;
    using Interfaces;

    /// <summary>
    /// The attack command.
    /// </summary>
    public class AttackCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttackCommand"/> class.
        /// </summary>
        /// <param name="gameEngine">
        /// The game engine.
        /// </param>
        public AttackCommand(IGameEngine gameEngine)
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
            string attackerName = commandArgs[1];
            string targetName = commandArgs[2];

            IStarship attackingShip = this.GetStarshipByName(attackerName);
            IStarship targetShip = this.GetStarshipByName(targetName);

            this.ProcessStarshipBattle(attackingShip, targetShip);
        }

        /// <summary>
        /// The process starship battle.
        /// </summary>
        /// <param name="attackingShip">
        /// The attacking ship.
        /// </param>
        /// <param name="targetShip">
        /// The target ship.
        /// </param>
        /// <exception cref="ShipException">
        /// </exception>
        private void ProcessStarshipBattle(IStarship attackingShip, IStarship targetShip)
        {
            this.ValidateAlive(attackingShip);
            this.ValidateAlive(targetShip);

            if (attackingShip.Location != targetShip.Location)
            {
                throw new ShipException(Messages.NoSuchShipInStarSystem);
            }

            IProjectile attack = attackingShip.ProduceAttack();
            targetShip.RespondToAttack(attack);
            Console.WriteLine(Messages.ShipAttacked, attackingShip.Name, targetShip.Name);

            if (targetShip.Shields < 0)
            {
                targetShip.Shields = 0;
            }

            if (targetShip.Health <= 0)
            {
                targetShip.Health = 0;
                Console.WriteLine(Messages.ShipDestroyed, targetShip.Name);
            }
        }
    }
}