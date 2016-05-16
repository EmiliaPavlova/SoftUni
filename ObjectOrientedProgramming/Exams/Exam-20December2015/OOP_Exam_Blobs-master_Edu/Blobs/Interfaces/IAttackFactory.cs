namespace Blobs.Interfaces
{
    public interface IAttackFactory
    {
        IAttack Create(string attackName);
    }
}