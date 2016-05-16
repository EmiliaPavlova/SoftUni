namespace Blobs.Models.Attacks
{
    using Interfaces;

    public class Blobplode : BaseAttack
    {
        public override void ExecuteAttack(IBlob target, int damage)
        {
            damage = damage * 2;
            target.Respond(damage);
        }

        public override void ExecuteEffectsOnAttacker(IBlob attacker)
        {
            attacker.Health -= attacker.Health / 2;
        }
    }
}