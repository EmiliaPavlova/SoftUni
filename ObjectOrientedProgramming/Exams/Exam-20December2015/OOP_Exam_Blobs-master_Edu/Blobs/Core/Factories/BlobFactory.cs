namespace Blobs.Core.Factories
{
    using Interfaces;
    using Models;

    public class BlobFactory : IBlobFactory
    {
        public IBlob Create(string name, int health, int damage, IBehavior behavior, IAttack attack)
        {
            return new Blob(name, health, damage, behavior, attack);
        }
    }
}
