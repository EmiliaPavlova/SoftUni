namespace Blobs.Models.Behaviors
{
    using System;
    using Interfaces;

    public class Aggressive : BaseBehavior
    {
        private const int DamageReductionValue = 5;

        private int initialBlobDamage;

        public override void Trigger(IBlob blob)
        {
            if (this.AlreadyTriggered)
            {
                throw new InvalidOperationException(ExceptionMessage);
            }

            this.IsTriggered = true;
            this.AlreadyTriggered = true;
            this.initialBlobDamage = blob.Damage;
            blob.Damage = blob.Damage * 2;
        }

        public override void PerformNegativeEffects(IBlob blob)
        {
            if (ShouldDelayBeforeExecution)
            {
                this.ShouldDelayBeforeExecution = false;
            }
            else
            {
                if (blob.Damage - DamageReductionValue < initialBlobDamage)
                {
                    this.IsTriggered = false;
                }
                else
                {
                    blob.Damage -= DamageReductionValue;
                }
            }
        }
    }
}
