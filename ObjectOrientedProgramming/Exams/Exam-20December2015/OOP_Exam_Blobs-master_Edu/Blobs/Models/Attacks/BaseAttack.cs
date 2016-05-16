namespace Blobs.Models.Attacks
{
    using Interfaces;

    public abstract class BaseAttack : IAttack
    {
        public abstract void ExecuteAttack(IBlob target, int damage);

        public abstract void ExecuteEffectsOnAttacker(IBlob attacker);
    }
}
