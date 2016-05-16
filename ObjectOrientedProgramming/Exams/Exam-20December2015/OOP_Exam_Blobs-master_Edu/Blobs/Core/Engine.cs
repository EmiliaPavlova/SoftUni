namespace Blobs.Core
{
    using System;
    using System.Linq;
    using Interfaces;
    using Models.Events;

    public class Engine : IRunnable
    {
        private readonly IBlobFactory blobFactory;
        private readonly IAttackFactory attackFactory;
        private readonly IBehaviorFactory behaviorFactory;
        private readonly IInputReader reader;
        private readonly IOutputWriter writer;
        private readonly IBlobData blobData;

        private bool shouldReportEvents;

        public Engine(IBlobFactory blobFactory, IAttackFactory attackFactory, IBehaviorFactory behaviorFactory,
            IInputReader reader, IOutputWriter writer, IBlobData blobData)
        {
            this.blobFactory = blobFactory;
            this.attackFactory = attackFactory;
            this.behaviorFactory = behaviorFactory;
            this.reader = reader;
            this.writer = writer;
            this.blobData = blobData;

            this.shouldReportEvents = false;
        }

        public virtual void Run()
        {
            while (true)
            {
                var input = this.reader.Read();

                this.ExecuteInput(input.Split());
                this.UpdateBlobs();
            }
        }

        protected virtual void ExecuteInput(string[] args)
        {
            string command = args[0];

            switch (command)
            {
                case "create":
                    this.ExecuteCreateCommand(args);
                    break;
                case "attack":
                    this.ExecuteAttackCommand(args);
                    break;
                case "pass":
                    break;
                case "status":
                    this.ExecuteStatusReportCommand();
                    break;
                case "report-events":
                    this.shouldReportEvents = true;
                    break;
                case "drop":
                    Environment.Exit(0);
                    break;
                default:
                    throw new ArgumentException("Undefined command");
            }
        }

        private void ExecuteCreateCommand(string[] creationArgs)
        {
            var name = creationArgs[1];
            var health = int.Parse(creationArgs[2]);
            var damage = int.Parse(creationArgs[3]);

            var behaviorType = creationArgs[4];
            var behavior = behaviorFactory.Create(behaviorType);

            var attackType = creationArgs[5];
            var attack = attackFactory.Create(attackType);

            var blob = blobFactory.Create(name, health, damage, behavior, attack);

            if (this.shouldReportEvents)
            {
                blob.OnBehaviorToggled += this.PrintBehaviorToggled;
                blob.OnBlobDead += this.PrintBlobDead;
            }

            this.blobData.AddBlob(blob);
        }

        private void ExecuteAttackCommand(string[] attackArgs)
        {
            var attackerName = attackArgs[1];
            var defenderName = attackArgs[2];

            var attacker = this.blobData.Blobs
                .FirstOrDefault(b => b.Name == attackerName);
            var defender = this.blobData.Blobs
                .FirstOrDefault(b => b.Name == defenderName);

            if (attacker == null || defender == null)
            {
                throw new ArgumentException("Blob was not found");
            }

            if (attacker.IsAlive && defender.IsAlive)
            {
                attacker.PerformAttack(defender);
            }
        }

        private void ExecuteStatusReportCommand()
        {
            var output = string.Join("\n", this.blobData.Blobs);

            this.writer.Write(output);
        }

        private void UpdateBlobs()
        {
            foreach (var blob in this.blobData.Blobs
                .Where(b => b.Behavior.IsTriggered))
            {
                blob.Update();
            }
        }

        private void PrintBehaviorToggled(object sender, BehaviorToggledEventArgs e)
        {
            this.writer.Write(e.Message);
        }

        private void PrintBlobDead(object sender, BlobDeadEventArgs e)
        {
            this.writer.Write(e.Message);
        }
    }
}