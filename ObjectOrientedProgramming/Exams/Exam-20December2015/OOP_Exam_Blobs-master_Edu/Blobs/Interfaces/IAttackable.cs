namespace Blobs.Interfaces
{
    using Models.EventHandlers;

    public interface IAttackable
    {
        void Respond(int damage);

        event BlobDeadEventHandler OnBlobDead;
    }
}