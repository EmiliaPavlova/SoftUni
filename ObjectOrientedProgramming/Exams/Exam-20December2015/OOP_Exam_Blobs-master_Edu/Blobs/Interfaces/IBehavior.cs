namespace Blobs.Interfaces
{
    public interface IBehavior
    {
        void Trigger(IBlob blob);

        void PerformNegativeEffects(IBlob blob);

        bool IsTriggered { get; }

        bool AlreadyTriggered { get; }
    }
}